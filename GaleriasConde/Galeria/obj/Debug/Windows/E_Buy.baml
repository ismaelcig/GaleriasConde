   M S B A M L   `   `   `  ����B  >Galeria, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Galeria.WindowsGaleria.Windows  5   	   P LElysium, Version=2.0.976.4, Culture=neutral, PublicKeyToken=afa220db249e5b15D/clr-namespace:Elysium.Controls;assembly=ElysiumElysium.Controls 5   	   =#clr-namespace:Galeria.User_ControlsGaleria.User_Controls  5   	       Galeria.Windows.E_Buy   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Galeria.Windows     5   	   DControls/clr-namespace:Elysium.Controls;assembly=Elysium     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   /metro#http://schemas.codeplex.com/elysium  5
   	   7params*http://schemas.codeplex.com/elysium/params  5   	   7User_Controls#clr-namespace:Galeria.User_Controls  5   	   -   5          Elysium.Parameters.Design    Theme$  LightX�5   	      Elysium.Parameters.Manager   Theme$ LightX�5   	      AccentBrush$ 
BlueViolet��5   	      ContrastBrush$ BlanchedAlmond��5   	   $
��Bold"�5   	   $��15(�5   	   $X��Rpack://application:,,,/MaterialDesignThemes.Wpf;component/Resources/Roboto/#Roboto)�5   	      BUYtitle � Title# �   5   	   $��321.09��6,   $��589.85��6<    � 
ResizeMode$ CanMinimize=�6b   .��5      � .+�5   
   �� 
���   �$��1q�6%   $
��Left=�69   $	��200��6T   $��	10,10,0,0q�6a   $	��Top=�6t   $	��200��6�   ._�5      �� -   5         ��Name$ image��5      5      �� 5   
   -   5         ��Name$
 lbl1��5       
 BTitle#���  6   $
��Left=�6A   $��
215,10,0,0q�6\   $	��Top=�6p   $
��Bold"�6�   $��15(�6�   �� 5   
   -   5        $ lblName��5      $�� ��6!   $
��Left=�6,   $��
257,10,0,0q�6G   $	��Top=�6[   $��DemiBold"�6s   $��15(�6�   �� 5   
   -   5        $
 lbl2��5        BAuthor#���  6   $
��Left=�6B   $��
216,43,0,0q�6]   $	��Top=�6q   �� 5   
   -   5         ��Name$ bAuth��5      $��Autor��6    $
��Left=�61   $��
265,41,0,0q�6L   $	��Top=�6`   $
��Auto��6x   6�   �� 5    
   -   5        $
 lbl3��5        	 BDate#���  6   $
��Left=�6@   $��
217,76,0,0q�6[   $	��Top=�6o   �� 5!   
   -   5        $ lblDate��5!      $�� ��6!   $
��Left=�6,   $��
275,76,0,0q�6G   $	��Top=�6[   $��DemiBold"�6s   �� 5#   
   -	   5        $
 lbl4��5#        BDim#���  6   $
��Left=�6?   $��217,109,0,0q�6Z   $	��Top=�6o   �� 5$   
   -
   5        $ lblDim��5$      $�� ��6    $
��Left=�6+   $��325,109,0,0q�6F   $	��Top=�6[   $��DemiBold"�6s   �� 5&   
   -   5        $
 lbl5��5&       
 BDescr#���  6   $
��Left=�6A   $��217,142,0,0q�6\   $	��Top=�6q   �� 5'   
   -   5        	 ��Name$	 descr��5'      $
��Left=�6#   $��216,170,0,0q�6>   $
��Wrap=�6S   $��	TextBlock��6g   $	��Top=�6x   $��11(�6�   �� 5)   
   -   5        
 ��Name$
 checkBox��5)        	Avaliable#���  6%   {�.  $
��Left=�6]   $��
60,215,0,0q�6x   $	��Top=�6�   �� 5*   
   -   5        $
 bBuy��5*       	 BUYb1#���  6   $
��Left=�6A   $��
60,236,0,0q�6\   $	��Top=�6p   $
��Auto��6�   6�   � 5,   
   -   5         �Name$ shadow��5,      $y�Hidden=�6    K� ZIndex$ 50��63   $��Stretch=�6E   $��Stretch=�6a   $��2��6   ��5-      �� 5.       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67    �� Opacity$
 0.85Q�6J   .��5/      �  � Color$ Black��6#    � Offset$ 0Q�61   � 50      $ 	#FF7A7171��6#   $ 1Q�65   51      53      � 54   
   -   5        $
 show��54      $	 100��6   55      56      