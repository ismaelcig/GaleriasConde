   M S B A M L   `   `   `  ����B  >Galeria, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:Galeria.User_Controls.Management_Windows(Galeria.User_Controls.Management_Windows  5      P LElysium, Version=2.0.976.4, Culture=neutral, PublicKeyToken=afa220db249e5b15D/clr-namespace:Elysium.Controls;assembly=ElysiumElysium.Controls 5   	   =#clr-namespace:Galeria.User_ControlsGaleria.User_Controls  5   	   6    0Galeria.User_Controls.Management_Windows.MngArts   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Hlocal6clr-namespace:Galeria.User_Controls.Management_Windows     5      DControls/clr-namespace:Elysium.Controls;assembly=Elysium     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   /metro#http://schemas.codeplex.com/elysium  5
   	   7params*http://schemas.codeplex.com/elysium/params  5   	   7User_Controls#clr-namespace:Galeria.User_Controls  5   	     Elysium.Parameters.Design    Theme$  LightX�5   	      Elysium.Parameters.Manager   Theme$ LightX�5   	      AccentBrush$ 
BlueViolet��5   	      ContrastBrush$ BlanchedAlmond��5   	   $
��Bold"�5   	   $��15(�5   	   $X��Rpack://application:,,,/MaterialDesignThemes.Wpf;component/Resources/Roboto/#Roboto)�5   	   .��5      � 
�������.+�5   
   �� ���#688CAF$��1q�6'   $
��Auto��6;   $
��Auto��6H   ._�5      � .+�5      #  Elysium.Controls.ToggleSwitch  -   5          Name$ checkBox��5   %   $
��Left=�67   $��	67,28,0,0q�6R   $	��Top=�6e   �� 5      -   5         ��Name$ label1��5      $��On Stock��6(   $
��Left=�6;   $��
115,22,0,0q�6V   $	��Top=�6j   �� 5      -   5         ��Name$ txtID��5      {�.  $
��Left=�6;   $��40��6V   $��	10,10,0,0q�6b    �� TextWrapping$
 Wrap=�6u   $	��Top=�6�   $��55��6�      ID)  #MaterialDesignThemes.Wpf.HintAssist   Hint# �   6�   	   
IsFloating	 .  	 mdTxt#��[ 6  �� 5      -   5        $ txtTitle��5      
 �� 	MaxLength$	
 125��6,   $
��Left=�6<   $��40��6W   $��	10,51,0,0q�6c   $
 Wrap=�6v   $�� ��6�   $	��Top=�6�   $	��226��6�     realName# �  6�   	 . #��[ 6  �� 5      -   5         ��Name$ comboBoxAut��5      $
��Left=�60   $��	10,90,0,0q�6K   $	��Top=�6^   $��40��6v   $	��120��6�     Auth# �  6�   	 .   mdCombo#��[ 6�   �� 5      -   5        $ comboBoxType��5      $
��Left=�61   $��
10,130,0,0q�6L   $	��Top=�6`   $��40��6x   $	��120��6�     Type# �  6�   	 . #��[ 6�   �� 5      -   5        $ txtMoney��5      $
��Left=�6,   $��40��6G   $��
10,170,0,0q�6S   $
 Wrap=�6g   $�� ��6{   $	��Top=�6�   $	��100��6�    	 Money# �  6�   	 . #��[ 6  �� 5       -   5        $ txtDate��5       $
��Left=�6+   $��40��6F   $��
10,210,0,0q�6R   $
 Wrap=�6f   $�� ��6z   $	��Top=�6�   $	��120��6�     date# �  6�   	 . #��[ 6
  �� 5!      -	   5        $ txtDim��5!      $
��Left=�6*   $��40��6E   $��
10,250,0,0q�6Q   $
 Wrap=�6e   $�� ��6y   $	��Top=�6�   $	��226��6�     
dimensions# �  6�   	 . #��[ 6  �� 5"      -
   5        $ txtinfo��5"      $
��Left=�6+   $��10,290,0,40q�6F   $
 Wrap=�6[   $�� ��6o   $��Stretch=�6w   $	��226��6�    �� AcceptsReturn . $	��Top=�6�    		 descr# � 	 6�   	 . #��[ 68  �� 5#      
���   �$��1q�6-   $��
130,90,0,0q�6A   $	��120��6U   $	��110��6b   $
��Left=�6n   $	��Top=�6�   ._�5$      �� -   5         ��Name$	 img��5$      5%      �� 5'      -   5         ��Name$ buttAdd��5'       

 CG4Add#��� 
 6*   $
��Left=�6M   $��15,0,0,5q�6h   $��Bottom=�6z   $��95��6�   6�   �� 5(      -   5        $ buttMod��5(       
 CG4Mod#���  6*   $
��Left=�6M   $��	135,0,0,5q�6h   $��Bottom=�6{   $��95��6�   6�   C   =Galeria.User_Controls.Management_Windows.MultiLanguageWarning  5)      $
��Left=�6-   $��
195,10,0,0q�6H   $	��Top=�6\   �� 5*      -   5        $ imgSelector��5*        img#���  6.   $
��Left=�6N   $��130,210,0,0q�6i   $	��Top=�6~   $	��110��6�   $��40��6�   
���\\��
���**��$
��Bold"�6�   �� 5+      -   5        $ label��5+      $	��€��6'   $
��Left=�63   $��106,182,0,0q�6N   $	��Top=�6c   5,      5-      &   System.Windows.Controls.DataGrid  5.   
   -   5          Name$ dataGrid��5.      $��Stretch=�6%   $��	240,0,0,0q�6C   $��Stretch=�6V     dg#��[ 6�    � DataContext 6r   ��  �� Source$ 	ArtworkVO��   Columns 5/      0  *System.Windows.Controls.DataGridTextColumn  50      1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *	ArtworkID+,	  &System.Windows.Controls.DataGridColumn 	  Header 51      �� 52      #���   6$   $��Center=�6@   54        55       6%   �� *title+ 56      �� 57       	 Title#���  6$   $��Center=�6C   59      4
  .System.Windows.Controls.DataGridCheckBoxColumn
  5:       6)   �� *	onStock+ 5;      �� 5<        onStock#���  6$   $��Center=�6E   5>        5?       6%   �� *authorVO.artName+ 5@      �� 5A      #���  6$   $��Center=�6B   5C        5D       6%   �� *typeVO.codType+ 5E      �� 5F      #���  6$   $��Center=�6B   5H        5I       6%   �� *date+ 5J      �� 5K      #���  6$   $��Center=�6B   5M        5N       6%   �� *
dimensions+ 5O      �� 5P      #���  6$   $��Center=�6H   5R      5[      5\      5]      