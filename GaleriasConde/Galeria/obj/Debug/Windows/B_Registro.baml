   M S B A M L   `   `   `  ����P  LElysium, Version=2.0.976.4, Culture=neutral, PublicKeyToken=afa220db249e5b15D/clr-namespace:Elysium.Controls;assembly=ElysiumElysium.Controls  5   	   B >Galeria, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Galeria.User_ControlsGaleria.User_Controls 5   	       Galeria.Windows.B_Registro   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   DControls/clr-namespace:Elysium.Controls;assembly=Elysium     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   /metro#http://schemas.codeplex.com/elysium   5   	   7params*http://schemas.codeplex.com/elysium/params   5   	   7User_Controls#clr-namespace:Galeria.User_Controls   5   	   -   5           Elysium.Parameters.Design    Theme$  LightX�5   	       Elysium.Parameters.Manager   Theme$ LightX�5	   	      AccentBrush$ 
BlueViolet��5
   	      ContrastBrush$ BlanchedAlmond��5   	   $
��Bold"�5   	   $��15(�5   	   $X��Rpack://application:,,,/MaterialDesignThemes.Wpf;component/Resources/Roboto/#Roboto)�5   	      CloseWin   Elysium.Parameters.Window   CloseButtonToolTip# �   5   	     MinimizeApp   MinimizeButtonToolTip# �  5   	    � WindowStartupLocation$ CenterScreen=�5   	     RGtitle � Title# �  5   	   $	��313��6+   $��358.331��68    � 
ResizeMode$ CanMinimize=�6H   	 � 	Resources	 5      
 �� 
TargetType  MaterialDesignTextBox �� BasedOn  MaterialDesignPasswordBox  MaterialDesignComboBox��%�   '��       7  'G� "     7  '�� D     7  �� 5   
   "
 ��6   8   6.   �� 5   
   "
 G�6   8   62   �� 5   
   "
 ��6   8   6/   5      .��5      �  � DataContext 6   ��  �� Source$ Usuario��.+�5   
   ,  &Galeria.User_Controls.LanguageSelector  $��Right=�6)   $	��Top=�6E   $��	0,10,10,0q�6]    K� ZIndex$ 10��6p   � 5!   
   -   5         �Name$ 	gridDatos��5!      .+�5"      �� -   5         ��Name$ txt1Name��5"       �� 	MaxLength$ 25��6(   $��1��6�   $
��Left=�6�   $��40��6�   $��	10,10,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6  $	��158��6&  )  #MaterialDesignThemes.Wpf.HintAssist   Hint# � ��62     
IsFloating . ��67   ��  �� Path$ nombre� �� UpdateSourceTrigger$ PropertyChanged=� �� NotifyOnValidationError .  �� ValidatesOnDataErrors . 6j  �� 5#      -   5        $ 	txt2Apell��5#      $ 25��6)   $��2��6�   $
��Left=�6�   $��40��6�   $��	10,55,0,0q�6�   $
 Wrap=�6�   $	��Top=�6  $	��330��6*    Surnames# �  66   . ��68   �� $ 	apellidos�$ PropertyChanged=� .  . 6r  �� 5$      -   5        $ txt3Nick��5$      $ 25��6(   $��3��6�   $
��Left=�6�   $��40��6�   $��
10,100,0,0q�6�   $
 Wrap=�6�   $	��Top=�6  $	��158��6%    Nick# �  61   . ��67   �� $
 nick�$ PropertyChanged=� .  . 6i  �� 5%      -   5         ��Name$ comboBox��5%      $��4��6)   $
��Left=�66   $��184,100,0,0q�6Q   $	��Top=�6f   $	��158��6~     Nat# �  6�    . $��40��6�   �� 5&      -   5        $ txt4Dir��5&      $��5��6�   $
��Left=�6�   $��40��6�   $��
10,145,0,0q�6�   $
 Wrap=�6�   $	��Top=�6  $	��330��6   	 Address# � 	 6&   . ��6'   �� $ 	direccion�$ PropertyChanged=� .  . 6a  �� 5'      -   5        $ 	txt5Email��5'      $��6��6�   $
��Left=�6�   $��40��6�   $��
10,190,0,0q�6�   $
 Wrap=�6�   $	��Top=�6   $	��158��6   	
 Email# � 
 6$   . ��6)   �� $ email�$ PropertyChanged=� .  . 6]  �� 5(      -	   5        $ txt6Tlf��5(      $��7��6�   $
��Left=�6�   $��40��6�   $��182,190,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��158��6    Tlf# �  6!   . ��6'   �� $	 tlf�$ PropertyChanged=� .  . 6X  �� 5)      -
   5         ��Name$ buttSig��5)        Next#���  6&   $
��Left=�6G   $��	43,0,0,10q�6b   $��Bottom=�6u   $��92��6�   6�   �� 5*      -   5        $ 
buttCancel��5*        RGb2#���  6)   $��Right=�6J   $��	0,0,47,10q�6f   $��Bottom=�6y   $	��164��6�   6�   5+      � 5-   
   -   5        $ gridPass��5-      $��Stretch=�6!   $y�Hidden=�6?   $��Stretch=�6S   
�������.+�5.      G� -   5         G�Name$ passwordBox1��5.      $
��Left=�60   $��	43,46,0,0q�6K   $	��Top=�6^   $��40��6v   $	��265��6�    
 RGpass# �  6�    . 6  G� 5/      -   5        $ passwordBox2��5/      $
��Left=�60   $��	43,86,0,0q�6K   $	��Top=�6^   $��40��6v   $	��265��6�     RGpass1# �  6�    . 6  #   Elysium.Controls.ToggleSwitch  50      -   5          Name$ check1��50   !      	IsChecked .  {�.  $
��Left=�6U   $��
10,131,0,0q�6p   $	��Top=�6�     51      -   5        $ check2��51   !    .  {�.  $
��Left=�6U   $��
10,155,0,0q�6p   $	��Top=�6�     52      -   5        $ check3��52   !    .  {�.  $
��Left=�6U   $��
10,179,0,0q�6p   $	��Top=�6�     53      -   5        $ check4��53   !    .  {�.  $
��Left=�6U   $��
10,203,0,0q�6p   $	��Top=�6�     54      -   5        $ check5��54   !    .  {�.  $
��Left=�6U   $��
10,224,0,0q�6p   $	��Top=�6�   �� 55        RGcheck1#���  6   $
��Left=�69   $��
60,125,0,0q�6T   $	��Top=�6h   �� 56        RGcheck2#���  6   $
��Left=�69   $��
60,149,0,0q�6T   $	��Top=�6h   �� 57        RGcheck3#���  6   $
��Left=�69   $��
60,173,0,0q�6T   $	��Top=�6h   �� 58        RGcheck4#���  6   $
��Left=�69   $��
60,197,0,0q�6T   $	��Top=�6h   �� 59        RGcheck5#���  6   $
��Left=�69   $��
60,218,0,0q�6T   $	��Top=�6h   �� 5;      -   5        $ buttConfirmar��5;        Ok#���  6,   $
��Left=�6K   $��	70,0,0,10q�6f   $��Bottom=�6y   $	��100��6�   6�   �� 5<      -   5        $ buttBack��5<        Back#���  6'   $��Right=�6H   $��	0,0,70,10q�6d   $��Bottom=�6w   $	��100��6�   6�   5>      5?      5@      