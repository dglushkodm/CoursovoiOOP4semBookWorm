   M S B A M L   `   `   `  ����B  >CursOOP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:CursOOP.Views.AdminCursOOP.Views.Admin  5      '    !CursOOP.Views.Admin.BookCardAdmin   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:CursOOP.Views.Admin     5      -   5          >�Name$  UserControl��5      $	��210��5	      $	��130��6    � 	Resources 5
      '   !CursOOP.Views.Admin.BookCardAdmin �� 
TargetType �� Property �� Value �� 	Resources   Key��%u  '        �� 5   
   "  6   .�5      ��  � ��$ 20q�6'   64    5      ���� 5      '��       " ��6   
Shadow  .�5      ��  � ��
 �   �63   �� 5       �@J�Opacity$	 0.5Q�60   5      �� 5      Name  " ��6%   .�5      ��  � ��
 �����63   �� 5       � ��$ 10(�61   5      5      5      5      .��5      � -   5         �Name$ myGrid��5       � RowDefinitions 5      �� 5      $��* �6$   �� 5      $��* �6$   �� 5      $��* �6$    � Triggers 5       :� 5!      	 :� RoutedEvent$	 
MouseEnter��6'   .[�5"      �� .��5#   "   �� .��5$   &   W� 	
 W� To
 166    g� Duration$ 0:0:0.3D�6=    �� 
TargetName$ button1��6P    �� TargetProperty$ Opacity�6p   W� 5%   &   
 166   $ 0:0:0.3D�6=   $ button2��6P   $ Opacity�6p   W� 5&   &   
 0.5566   $ 0:0:0.3D�6@   $ button3��6S   $ Opacity�6s   W� 5'   &   
 14066   $ 0:0:0.3D�6?   $ UserControl��6R   $ Width�6v   W� 5(   &   
 22066   $ 0:0:0.3D�6?   $ UserControl��6R   $ Height�6v   5)   #   5*      5+      :� 5,      $	 
MouseLeave��6'   .[�5-      �� .��5.   "   �� .��5/   &   W� 
 066   $ 0:0:0.3D�6=   $ button1��6P   $ Opacity�6p   W� 50   &   
 066   $ 0:0:0.3D�6=   $ button2��6P   $ Opacity�6p   W� 51   &   
 066   $ 0:0:0.3D�6=   $ button3��6P   $ Opacity�6p   W� 52   &   
 13066   $ 0:0:0.3D�6?   $ UserControl��6R   $ Width�6v   W� 53   &   
 21066   $ 0:0:0.3D�6?   $ UserControl��6R   $ Height�6v   54   #   55      56      .+�59      �� $��3��6    �� CornerRadius$ 10��6.   ��5:      �� 5;       j� Stretch$ UniformToFill=�6*    �� ImageSource 6B   �� *Img+  ByteArrToImg �� 	Converter# [ ._�5=      �  5>      �� 5?   "   $��* �60   �� 5@   "   $��* �60   �� 5A   "   $��* �60   .+�5C      � $��2��6$   .+�5D   "   �� 
���   �$��Bottom=�6<    J� Opacity$
 0.70Q�6W   $ 	0,0,10,10��6f   ._�5E   &   �� -   5         ��Name$ NameTextBlock��5E   E   $
��Wrap=�60   
�������$ 1Q�6o   $��10(�6{   $��Center=�6�   $��Center=�6�   $��	0,15,0,15q�6�   ��6�   �� *Name+6�   5F   #   5G      �� 5H      -   5         ��Name$ button3��5H   6   
���  ��$ 0Q�6H   $ 	10,10,0,0��6T   $��0��6m   $	��top=�6z   ._�5I      � $	��top=�6$   .+�5K   "   �� -   5         ��Name$ button1��5K   p    � Cursor$F @D:\БГТУ\CursachOOP\CursOOP\CursOOP\Resources\Images\Link.cur��6*   $	��top=�6�   $��Right=�6�   $ 0Q�6�   $��20��6�   $	��0,5q�6�   ��5L   &   �� 5M   *    �� 
TargetType" ��6:   .R�5N   .   ��  ��Name$ button1��65   $H��BD:\БГТУ\CursachOOP\CursOOP\CursOOP\Resources\Images\delete.png��6G   6�   5O   +   5Q   #   �� 5R   "   -   5        $ button2��5R   o   $F @D:\БГТУ\CursachOOP\CursOOP\CursOOP\Resources\Images\Link.cur��6)   $��Right=�6�   $ 0Q�6�   $��20��6�   $
��30,5q�6�   ��5S   &   �� 5T   *   " ��6:   .R�5U   .   �� $ button2��65   $F��@D:\БГТУ\CursachOOP\CursOOP\CursOOP\Resources\Images\edit.png��6G   6�   5V   +   5X   #   5Y      5Z      5[      5\      5^      5_      