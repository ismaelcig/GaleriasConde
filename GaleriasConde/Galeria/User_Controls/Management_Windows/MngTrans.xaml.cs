﻿using Galeria.Dict;
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
        //CargarDiccionarios cd = new CargarDiccionarios();
        Transaction obj = new Transaction();
        //List<Transaction> transactions = new List<Transaction>();
        public MngTrans()
        {
            InitializeComponent();
            ReloadData();
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid.SelectedIndex > -1)
            {
                obj = new Transaction();
                obj = (Transaction)dataGrid.SelectedItem;
                txtID.Text = obj.TransactionID.ToString();
                comboBoxArt.SelectedItem = obj.Artwork;
                comboBoxUser.SelectedItem = obj.User;
                txtBenefit.Text = Math.Abs(obj.money).ToString();
                txtComment.Text = obj.comment;

                buttMod.IsEnabled = true;
                buttDel.IsEnabled = true;
            }
            else
            {
                buttMod.IsEnabled = false;
                buttDel.IsEnabled = false;

                txtID.Text = "";
                comboBoxArt.SelectedIndex = -1;
                comboBoxUser.SelectedIndex = -1;
                txtBenefit.Text = "";
                txtComment.Text = "";
                ReloadData();
            }
        }

        private void buttAdd_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxArt.SelectedIndex != -1 && comboBoxUser.SelectedIndex != -1 && !string.IsNullOrWhiteSpace(txtBenefit.Text))//Comment can be empty
            {//Rollback(?)
                try
                {
                    double benefit;
                    double.TryParse(txtBenefit.Text, out benefit);
                    if (benefit != 0)
                    {
                        Transaction t = new Transaction();
                        t.Artwork = ArtworkConverter.fromVO((ArtworkVO)comboBoxArt.SelectedItem);
                        t.comment = txtComment.Text;
                        t.done = checkBox.IsChecked;
                        t.money = benefit;
                        t.User = (User)comboBoxUser.SelectedItem;

                        A_Login.u.TransactionsRep.Create(t);//Creo el objeto Transaction
                        ReloadData();
                        dataGrid.SelectedIndex = 0;
                        dataGrid.SelectedIndex = -1;
                    }
                    else
                    {
                        MessageBox.Show((string)A_Login.dict["MngTr_Msg1"]);//valor inválido
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
                if (A_Login.user.nick == "master")
                {
                    if (comboBoxArt.SelectedIndex != -1 && comboBoxUser.SelectedIndex != -1 && !string.IsNullOrWhiteSpace(txtBenefit.Text))
                    {
                        double benefit;
                        double.TryParse(txtBenefit.Text, out benefit);

                        obj.Artwork = ArtworkConverter.fromVO((ArtworkVO)comboBoxArt.SelectedItem);
                        obj.comment = txtComment.Text;
                        obj.done = checkBox.IsChecked;
                        obj.money = benefit;
                        obj.User = (User)comboBoxUser.SelectedItem;
                        
                        A_Login.u.TransactionsRep.Update(obj);//Modifica el codNation
                        ReloadData();
                        dataGrid.SelectedIndex = -1;
                    }
                    else
                    {
                        MessageBox.Show((string)A_Login.dict["RG_Msg1"]);//Campo vacío
                    }
                }
                else
                {
                    MessageBox.Show((string)A_Login.dict["RG_Msg2"]);//Sólo master puede modificar transacciones
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
                    A_Login.u.TransactionsRep.Delete(A_Login.u.TransactionsRep.Single(c => c.TransactionID == obj.TransactionID));
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
            dataGrid.ItemsSource = A_Login.u.UsersRep.GetAll();
            Loaders.LoadArtworks(comboBoxArt);
            Loaders.LoadUsers(comboBoxUser);
        }
    }
}