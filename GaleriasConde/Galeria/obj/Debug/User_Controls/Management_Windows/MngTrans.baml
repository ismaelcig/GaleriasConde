   M S B A M L   `   `   `  ����B  >Galeria, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:Galeria.User_Controls.Management_Windows(Galeria.User_Controls.Management_Windows  5      P LElysium, Version=2.0.976.4, Culture=neutral, PublicKeyToken=afa220db249e5b15D/clr-namespace:Elysium.Controls;assembly=ElysiumElysium.Controls 5   	   =#clr-namespace:Galeria.User_ControlsGaleria.User_Controls  5   	   7    1Galeria.User_Controls.Management_Windows.MngTrans   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Hlocal6clr-namespace:Galeria.User_Controls.Management_Windows     5      DControls/clr-namespace:Elysium.Controls;assembly=Elysium     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   /metro#http://schemas.codeplex.com/elysium  5
   	   7params*http://schemas.codeplex.com/elysium/params  5   	   7User_Controls#clr-namespace:Galeria.User_Controls  5   	     Elysium.Parameters.Design    Theme$  LightX�5   	      Elysium.Parameters.Manager   Theme$ LightX�5   	      AccentBrush$ 
BlueViolet��5   	      ContrastBrush$ BlanchedAlmond��5   	   $
��Bold"�5   	   $��15(�5   	   $X��Rpack://application:,,,/MaterialDesignThemes.Wpf;component/Resources/Roboto/#Roboto)�5   	   .��5      � 
�������.+�5   
   �� ���#688CAF$��1q�6'   $
��Auto��6;   $
��Auto��6H   ._�5      � .+�5      �� -   5         ��Name$ txtID��5      {�.  $
��Left=�6;   $��40��6V   $��	10,10,0,0q�6b    �� TextWrapping$
 Wrap=�6u   $	��Top=�6�   $��55��6�      ID)  #MaterialDesignThemes.Wpf.HintAssist   Hint# �   6�      
IsFloating .  	 mdTxt#��[ 6  #  Elysium.Controls.ToggleSwitch  5      -   5          Name$ checkBox��5   %   $
��Left=�67   $��	95,25,0,0q�6R   $	��Top=�6e   �� 5      -   5        	 ��Name$	 comboBox��5      $
��Left=�6-   $��40��6H   $��	10,52,0,0q�6T   $	��Top=�6g   $	��220��6     	Operation# �  6�    .   mdCombo#��[ 6�   .@�5      �� -   5        
 ��Name$

 sell��5   #     Sell#���  61   �� 5      -   5        $	
 buy��5   #     Buy#���  60   5      �� 5        Done#���  6   $
��Left=�69   $��
150,20,0,0q�6T   $	��Top=�6h   �� 5      -   5        $	 comboBoxArt��5      {�.  $
��Left=�6B   $��40��6]   $��	10,92,0,0q�6i   $	��Top=�6|   $	��220��6�     Art# �  6�    . #��[ 6  �� 5       -   5        $	 comboBoxUser��5       $
��Left=�61   $��40��6L   $��
10,132,0,0q�6X   $	��Top=�6l   $	��220��6�     User# �  6�    . #��[ 6�   �� 5!      -   5        $ txtMoney��5!      $
��Left=�6,   $��40��6G   $��
10,172,0,0q�6S   $
 Wrap=�6g   $	��Top=�6{   $	��201��6�    		 Money# � 	 6�    . #��[ 6  �� 5"      -	   5        $ 
txtComment��5"      $
��Left=�6.   $��10,212,0,40q�6I   $
 Wrap=�6^   $��Stretch=�6r   $	��220��6�    �� AcceptsReturn . $	��Top=�6�    
 Comm# � 
 6�    . #��[ 62  �� 5$      -
   5         ��Name$ buttAdd��5$       
 CG4Add#���  6*   $
��Left=�6M   $��10,0,0,5q�6h   $��Bottom=�6z   $��70��6�   6�   �� 5%      -   5        $ buttMod��5%       
 CG4Mod#���  6*   $
��Left=�6M   $��85,0,0,5q�6h   $��Bottom=�6z   $��70��6�   6�   �� 5&      -   5        $ buttDel��5&       
 CG4Del#���  6*   $
��Left=�6M   $��	160,0,0,5q�6h   $��Bottom=�6{   $��70��6�   6�   �� 5'      -   5         ��Name$ label��5'      $	��€��6'   $
��Left=�63   $��211,189,0,0q�6N   $	��Top=�6c   $��23��6{   5(      5)      &   System.Windows.Controls.DataGrid  5*   
   -   5          Name$ dataGrid��5*      $��Stretch=�6%   $��	240,0,0,0q�6C   $��Stretch=�6V     dg#��[ 6�    � DataContext 6r   ��  �� Source$ TransactionVO��   Columns 5+      0  *System.Windows.Controls.DataGridTextColumn  5,      1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *TransactionID+,  &System.Windows.Controls.DataGridColumn   Header 5-      �� 5.      #���   6$   $��Center=�6@   50        51       6%   �� *ArtworkVO.title+ 52      �� 53      #���  6$   $��Center=�6A   55        56       6%   �� *	User.nick+ 57      �� 58      #���  6$   $��Center=�6B   5:        5;       6%   �� *money+ 5<      �� 5=      #��� 	 6$   $��Center=�6C   5?        5@      -   5        regBycolumn�� 5@   :   �� *registeredBy.nick+ 5A      �� 5B       	 Admin#���  6$   5D        5E       6%   �� *	comment+ 5F      �� 5G      #��� 
 6$   $��Center=�6B   5I      5K      5L      5M      