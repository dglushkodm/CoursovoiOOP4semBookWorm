   M S B A M L   `   `   `  ����B  >CursOOP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:CursOOP.Views.UserCursOOP.Views.User  5      A%clr-namespace:CursOOP.ViewModels.UserCursOOP.ViewModels.User  5      %    CursOOP.Views.User.BookCardUser   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:CursOOP.Views.User     5      <
viewmodels%clr-namespace:CursOOP.ViewModels.User     5      -   5          >�Name$  UserControl��5      $	��210��5
      $	��130��6    � 	Resources 5      %   CursOOP.Views.User.BookCardUser �� 
TargetType �� Property �� Value �� 	Resources   Key��%u  '        �� 5   
   "  6   .�5      ��  � ��$ 20q�6'   64    5      ���� 5      '��       " ��6   
Shadow  .�5      ��  � ��
 �   �63   �� 5       �@J�Opacity$	 0.5Q�60   5      �� 5      Name  " ��6%   .�5      ��  � ��
 �����63   �� 5       � ��$ 10(�61   5      5      5      5      .��5      � -   5         �Name$ myGrid��5       � RowDefinitions 5      �� 5      $��* �6$   �� 5      $��* �6$   �� 5       $��* �6$    � Triggers 5"      :� 5#      	 :� RoutedEvent$	 
MouseEnter��6'   .[�5$      �� .��5%   "   �� .��5&   &   W� 	
 W� To
 14066    g� Duration$ 0:0:0.3D�6?    �� 
TargetName$ UserControl��6R    �� TargetProperty$ Width�6v   W� 5'   &   
 22066   $ 0:0:0.3D�6?   $ UserControl��6R   $ Height�6v   W� 5(   &   
 166   $ 0:0:0.3D�6=   $ button1��6P   $ Opacity�6p   5)   #   5*      5+      :� 5,      $	 
MouseLeave��6'   .[�5-      �� .��5.   "   �� .��5/   &   W� 
 13066   $ 0:0:0.3D�6?   $ UserControl��6R   $ Width�6v   W� 50   &   
 21066   $ 0:0:0.3D�6?   $ UserControl��6R   $ Height�6v   W� 51   &   
 066   $ 0:0:0.3D�6=   $ button1��6P   $ Opacity�6p   52   #   53      54      .+�57      �� $��3��6    �� CornerRadius$ 10��6.   ��58      �� 59       j� Stretch$ UniformToFill=�6*    �� ImageSource 6B   �� *Img+  ByteArrToImg �� 	Converter# [ ._�5;      �  5<      �� 5=   "   $��* �60   �� 5>   "   $��* �60   �� 5?   "   $��* �60   .+�5A      � $��2��6$   .+�5B   "   �� 
���   �$��Bottom=�6<    J� Opacity$
 0.70Q�6W   $ 	0,0,10,10��6f   ._�5C   &   �� -   5         ��Name$ NameTextBlock��5C   E   $
��Wrap=�60   
�������$ 1Q�6o   $��10(�6{   $��Center=�6�   $��Center=�6�   $��	0,15,0,15q�6�   ��6�   �� *Name+6�   5D   #   5E      �� 5F      -   5         ��Name$ button1��5F   l    � Cursor$F @D:\БГТУ\CursachOOP\CursOOP\CursOOP\Resources\Images\Link.cur��6%   $	��top=�6}   $��Right=�6�   $ 0Q�6�   $��20��6�   $	��0,5q�6�   ��5G   "   �� 5H   &    �� 
TargetType" ��66   .R�5I   *   ��  ��Name$ button1��61   $F��@D:\БГТУ\CursachOOP\CursOOP\CursOOP\Resources\Images\like.png��6C   6�   5J   '   5L      5M      5N      5P      5Q      