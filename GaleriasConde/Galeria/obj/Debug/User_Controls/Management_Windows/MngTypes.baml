   M S B A M L   `   `   `  ����B  >Galeria, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:Galeria.User_Controls.Management_Windows(Galeria.User_Controls.Management_Windows  5      P LElysium, Version=2.0.976.4, Culture=neutral, PublicKeyToken=afa220db249e5b15D/clr-namespace:Elysium.Controls;assembly=ElysiumElysium.Controls 5   	   =#clr-namespace:Galeria.User_ControlsGaleria.User_Controls  5   	   7    1Galeria.User_Controls.Management_Windows.MngTypes   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Hlocal6clr-namespace:Galeria.User_Controls.Management_Windows     5      DControls/clr-namespace:Elysium.Controls;assembly=Elysium     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   /metro#http://schemas.codeplex.com/elysium  5
   	   7params*http://schemas.codeplex.com/elysium/params  5   	   7User_Controls#clr-namespace:Galeria.User_Controls  5   	     Elysium.Parameters.Design    Theme$  LightX�5   	      Elysium.Parameters.Manager   Theme$ LightX�5   	      AccentBrush$ 
BlueViolet��5   	      ContrastBrush$ BlanchedAlmond��5   	   $
��Bold"�5   	   $��15(�5   	   $X��Rpack://application:,,,/MaterialDesignThemes.Wpf;component/Resources/Roboto/#Roboto)�5   	   .��5      � 
�������.+�5   
   �� ���#688CAF$��1q�6'   $
��Auto��6;   $
��Auto��6H   ._�5      � .+�5      �� -   5         ��Name$ buttAdd��5       
  CG4Add#���   6*   $
��Left=�6M   $��
10,108,0,0q�6h   $	��Top=�6|   $��70��6�   $��0,6,0,6q�6�   �� 5      -   5        $ buttMod��5       
 CG4Mod#���  6*   $
��Left=�6M   $��
85,108,0,0q�6h   $	��Top=�6|   $��70��6�   $��0,6,0,6q�6�   �� 5      -   5        $ buttDel��5       
 CG4Del#���  6*   $
��Left=�6M   $��160,108,0,0q�6h   $	��Top=�6}   $��70��6�   $��0,6,0,6q�6�   �� 5      -   5         ��Name$ txtID��5      {�.  $
��Left=�6;   $��40��6V   $��	10,10,0,0q�6b    �� TextWrapping$
 Wrap=�6u   $	��Top=�6�   $��55��6�     ID)  #MaterialDesignThemes.Wpf.HintAssist   Hint# �  6�      
IsFloating .  	 mdTxt#��[ 6  �� 5      -   5        $ txtType��5      $
��Left=�6+   $��40��6F   $��	10,52,0,0q�6R   $
 Wrap=�6e   $	��Top=�6y   $	��220��6�     Type# �  6�    . #��[ 6  C   =Galeria.User_Controls.Management_Windows.MultiLanguageWarning  5      $
��Left=�6-   $��
180,10,0,0q�6H   $	��Top=�6\   5      5      &   System.Windows.Controls.DataGrid  5    
   -   5        	  Name$	 dataGrid��5       $��Stretch=�6%   $��	240,0,0,0q�6C   $��Stretch=�6V     dg#��[ 6�   
 � DataContext
 6r   ��  �� Source$ TypeVO��   Columns 5!      0  *System.Windows.Controls.DataGridTextColumn  5"      1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *TypeID+,  &System.Windows.Controls.DataGridColumn   Header 5#      �� 5$      #���  6$   $��Center=�6@   5&        5'       6%   �� *	codType+ 5(      �� 5)      #���  6$   $��Center=�6B   5+        5,       6%   �� *nArts+ 5-      �� 5.       	 NArts#���  6$   $��Center=�6C   50      53      54      55      