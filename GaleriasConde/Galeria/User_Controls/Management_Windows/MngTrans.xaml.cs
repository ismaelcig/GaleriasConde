using Galeria.Dict;
using Galeria.Model;
using Galeria.Other_Classes;
using Galeria.VO;
using Galeria.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Galeria.User_Controls.Management_Windows
{
    /// <summary>
    /// Interaction logic for MngTrans.xaml
    /// </summary>
    public partial class MngTrans : UserControl
    {
        CargarDiccionarios cd = new CargarDiccionarios();
        TransactionVO obj = new TransactionVO();
        List<TransactionVO> VOs = new List<TransactionVO>();
        public MngTrans()
        {
            InitializeComponent();
            if (A_Login.user.Profile.ProfileID >= 3)
            {
                ReloadData();
            }
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid.SelectedIndex > -1)
            {
                obj = new TransactionVO();
                obj = (TransactionVO)dataGrid.SelectedItem;
                txtID.Text = obj.TransactionID.ToString();
                if (obj.venta)
                {
                    comboBox.SelectedIndex = 0;
                    Loaders.LoadArtworks(comboBoxArt, true);
                }
                else
                {
                    comboBox.SelectedIndex = 1;
                    Loaders.LoadArtworks(comboBoxArt, false);
                }
                //comboBoxArt.SelectedItem = obj.ArtworkVO;
                int cont = 0;
                foreach (ArtworkVO item in comboBoxArt.ItemsSource)
                {
                    if (item.ArtworkID == obj.ArtworkVO.ArtworkID)
                    {
                        break;
                    }
                    cont++;
                }
                comboBoxArt.SelectedIndex = cont;
                comboBoxUser.SelectedItem = obj.User;
                txtMoney.Text = obj.money.ToString();
                txtComment.Text = obj.comment;

                if (A_Login.user.nick == obj.registeredBy.nick || A_Login.user.nick == "master")//Sólo quien lo ha registrado o master pueden hacer cambios
                {
                    buttMod.IsEnabled = true;
                    buttDel.IsEnabled = true;
                }
            }
            else
            {
                ReloadData();
            }
        }

        private void buttAdd_Click(object sender, RoutedEventArgs e)
        {
            if (comboBox.SelectedIndex != -1 && comboBoxArt.SelectedIndex != -1 && comboBoxUser.SelectedIndex != -1 && !string.IsNullOrWhiteSpace(txtMoney.Text))//Comment can be empty
            {//Rollback(?)
                try
                {
                    double money;
                    double.TryParse(txtMoney.Text, out money);
                    if (money > 0)
                    {
                        Transaction t = new Transaction();
                        t.comment = txtComment.Text;
                        t.money = money;
                        t.User = (User)comboBoxUser.SelectedItem;
                        t.Artwork = A_Login.u.ArtworksRep.Single(c => c.ArtworkID == (int)comboBoxArt.SelectedValue);
                        t.done = checkBox.IsChecked;
                        if (comboBox.SelectedIndex == 0)
                        { t.venta = true; }
                        else if (comboBox.SelectedIndex == 1)
                        { t.venta = false; }
                        UpdateObra(t);
                        t.registeredBy = A_Login.user.UserID;
                        A_Login.u.TransactionsRep.Create(t);//Creo el objeto Transaction
                        ReloadData();
                    }
                    else
                    {
                        MessageBox.Show((string)A_Login.dict["MngTr_Msg1"]);//Dinero incorrecto
                    }
                    
                }
                catch (Exception ex)
                {
                    ErrorLog.Log("MngTrans1", ex);
                }
            }
            else
            {
                MessageBox.Show((string)A_Login.dict["RG_Msg1"]);//Campo vacío
            }
        }

        private void buttMod_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (comboBoxArt.SelectedIndex != -1 && comboBoxUser.SelectedIndex != -1 && !string.IsNullOrWhiteSpace(txtMoney.Text))
                {
                    double money;
                    double.TryParse(txtMoney.Text, out money);
                    if (money != 0)
                    {//Es un dato válido
                        Transaction t = A_Login.u.TransactionsRep.Single(c => c.TransactionID == obj.TransactionID);
                        t.comment = txtComment.Text;
                        t.money = money;
                        t.User = A_Login.u.UsersRep.Single(c => c.UserID == (int)comboBoxUser.SelectedValue);
                        t.Artwork = A_Login.u.ArtworksRep.Single(c => c.ArtworkID == (int)comboBoxArt.SelectedValue);
                        t.done = checkBox.IsChecked;
                        if (comboBox.SelectedIndex == 0)
                        { t.venta = true; }
                        else if (comboBox.SelectedIndex == 1)
                        { t.venta = false; }
                        UpdateObra(t);
                        A_Login.u.TransactionsRep.Update(t);
                        
                        ReloadData();
                    }
                    else
                    {//Beneficio incorrecto
                        MessageBox.Show((string)A_Login.dict["MngTr_Msg1"]);//Beneficio incorrecto
                    }
                }
                else
                {
                    MessageBox.Show((string)A_Login.dict["RG_Msg1"]);//Campo vacío
                }
            }
            catch (Exception ex)
            {
                ErrorLog.Log("MngTrans2", ex);
            }
        }

        private void buttDel_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show((string)A_Login.dict["DelConfirmation"], (string)A_Login.dict["UPCaption"], MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    Transaction t = A_Login.u.TransactionsRep.Single(c => c.TransactionID == obj.TransactionID);
                    if (t.done)//Si la transacción se había realizado, la deshace
                    {
                        if (t.venta)
                        { t.Artwork.onStock = false; }
                        else
                        { t.Artwork.onStock = true; }
                    }
                    A_Login.u.TransactionsRep.Delete(t);

                    ReloadData();
                }
                catch (Exception ex)
                {
                    ErrorLog.Log("MngTrans3", ex);
                }
            }
        }


        public void ReloadData()
        {//Carga transacciones en el dataGrid
            dataGrid.ItemsSource = null;
            VOs.Clear();
            foreach (Transaction item in A_Login.u.TransactionsRep.GetAll())
            {
                VOs.Add(new TransactionVO(item.TransactionID));
            }
            dataGrid.ItemsSource = VOs;

            buttMod.IsEnabled = false;
            buttDel.IsEnabled = false;

            txtID.Text = "";
            comboBox.SelectedIndex = -1;
            comboBoxArt.SelectedIndex = -1;
            comboBoxUser.SelectedIndex = -1;
            txtMoney.Text = "";
            txtComment.Text = "";
            //Loaders.LoadArtworks(comboBoxArt);
            Loaders.LoadUsers(comboBoxUser);
            if (A_Login.user.Profile.ProfileID != 4)
            {
                regBycolumn.Visibility = Visibility.Hidden;
            }
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//Si se selecciona Venta,  carga las obras en posesión
         //Si se selecciona Compra, carga las obras que no están en Posesión
            if (comboBox.SelectedIndex == -1)
            {
                comboBoxArt.IsEnabled = false;
                comboBoxArt.SelectedIndex = -1;
                comboBox.ItemsSource = null;
                comboBoxUser.SelectedIndex = -1;
                txtMoney.Text = "";
                txtComment.Text = "";
            }
            else
            {
                comboBoxArt.IsEnabled = true;
                if (comboBox.SelectedIndex == 0)
                {//Sell
                    Loaders.LoadArtworks(comboBoxArt, true);
                }
                else if (comboBox.SelectedIndex == 1)
                {
                    Loaders.LoadArtworks(comboBoxArt, false);
                }
            }
        }

        void UpdateObra(Transaction t)
        {
            if (t.done)//Si la transacción se completa, actualiza el estado de la obra
            {
                if (t.venta)
                    { t.Artwork.onStock = false; }
                else
                    { t.Artwork.onStock = true; }
                A_Login.u.ArtworksRep.Update(t.Artwork);
            }
        }
    }
}
