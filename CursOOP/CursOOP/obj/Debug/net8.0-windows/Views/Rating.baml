   M S B A M L   `   `   `  ����B  >CursOOP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CursOOP.ViewsCursOOP.Views  5   	   7 clr-namespace:CursOOP.ConvertersCursOOP.Converters  5   	   7 clr-namespace:CursOOP.ViewModelsCursOOP.ViewModels  5   	       CursOOP.Views.Rating   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   -localclr-namespace:CursOOP.Views     5   	   0con clr-namespace:CursOOP.Converters     5   	   /vm clr-namespace:CursOOP.ViewModels     5   	      	PanelMain#��[  5	   	     � WindowStyle$
  None=�5   	    � Title$ Rating��5   	   $	��150��6   $	��400��6%    � WindowStartupLocation$ CenterScreen=�61    � DataContext 5      (   "CursOOP.ViewModels.RatingViewModel  5   
   6    � 	Resources 5      *   $CursOOP.Converters.StarFillConverter  StarFillConverter  	StarStyle �� 
TargetType �� Property �� Value �� 
TargetType	 F�Name
 �� Stretch �� RelativeSource �� Path �� 	Converter �� FallbackValue �� Triggers P� Property P� Value �� 
TargetName��%�  &	       &	      7    5   
   6    �� 5      " 	�6$   .�5      ��  � �� 5      �� 5      " 	�6&   .R�5      � .+�5      F� $	 StarPath��6#   �	����`��஻ gffff6n@433333-@��!��gffffFm@`ET�43333m@�]w43333Ck@43333�L@�F
 ��Ӡ>N
@I�	`1K
 q�	 �
 �	�`�
`�	fffff�`@`�
`����8
�������/@���
�����L0@ +�
hfffff"@ ?�
�lfffff@`�W���������{�������? I��
     �?�a�     @�����<k@633333@������k@     @������k@�o�����̼n@     O@������p@�@�r�������,]@@�	����̌]@�� �    @^@�7Hр9 {��gfffffW@@�m43333�U@@� 2:�KH�gffff�U@�	�@��Pp�@�Ӡ� p�``}�@Ys�����~����`	gffff6~@@��
�9�S �y�����|@ �$���`i}��Ӡ���b �)�����lz@ 6��.� @B�B*�/� ?����d�43333#v@�ˠ �43333#@�&���S�bwgfffff@`�� p� le@�S�n�gffff�~@gffff�z@�	��MJ�KH�@�H@�gffff&z@@�m�{K {��`�O�7H� Hq�,(Ӡ��@�����`�� d6� � 0�@���G�3��!S�0rgffff�j@���@u �`�������@43333h@�`�[�
������~@��
�����̼~@ +�
�����$}@ �x
23333�y@`�2
�����\w@������d@23333;u@ q�	�����7u@�����yd@������4u@�V�	23333[t@fffff�`@effffVs@�����W@�����Qr@dffff�K@�����gq@dffff�6@�����Oq@dffff�4@������p@bfffff*@�����p@������!@������n@������(@	$��20��5   #   $��20��6.   $
 Uniform=�6:   $��2q�6L   ��5   #   ��  �� *TemplatedParent+$ 	IsChecked�8   $ Transparent��5   L   5       5      P� 5       �@J�IsMouseOver$
 True��6=   . �5   "   �� $ StarPath��6)    � ��
 � ���6O   5       5"      5$      5%      5&      .��5'      � $��Center=�6   .+�5(   
   ��  �� Orientation$ 
Horizontal=�6   $��0,0,0,50q�6.   .+�5)      	�  � Cursor$F @D:\БГТУ\CursachOOP\CursOOP\CursOOP\Resources\Images\Link.cur��6   #��[ 6`   $��1��6�   ��6�   �� *RateCommand+6�   	� 5*      $F @D:\БГТУ\CursachOOP\CursOOP\CursOOP\Resources\Images\Link.cur��6   #��[ 6`   $��2��6�   ��6�   �� *RateCommand+6�   	� 5+      $F @D:\БГТУ\CursachOOP\CursOOP\CursOOP\Resources\Images\Link.cur��6   #��[ 6`   $��3��6�   ��6�   �� *RateCommand+6�   	� 5,      $F @D:\БГТУ\CursachOOP\CursOOP\CursOOP\Resources\Images\Link.cur��6   #��[ 6`   $��4��6�   ��6�   �� *RateCommand+6�   	� 5-      $F @D:\БГТУ\CursachOOP\CursOOP\CursOOP\Resources\Images\Link.cur��6   #��[ 6`   $��5��6�   ��6�   �� *RateCommand+6�   	� 5.      $F @D:\БГТУ\CursachOOP\CursOOP\CursOOP\Resources\Images\Link.cur��6   #��[ 6`   $��6��6�   ��6�   �� *RateCommand+6�   	� 5/      $F @D:\БГТУ\CursachOOP\CursOOP\CursOOP\Resources\Images\Link.cur��6   #��[ 6`   $��7��6�   ��6�   �� *RateCommand+6�   	� 50      $F @D:\БГТУ\CursachOOP\CursOOP\CursOOP\Resources\Images\Link.cur��6   #��[ 6`   $��8��6�   ��6�   �� *RateCommand+6�   	� 51      $F @D:\БГТУ\CursachOOP\CursOOP\CursOOP\Resources\Images\Link.cur��6   #��[ 6`   $��9��6�   ��6�   �� *RateCommand+6�   	� 52      $F @D:\БГТУ\CursachOOP\CursOOP\CursOOP\Resources\Images\Link.cur��6   #��[ 6`   $��10��6�   ��6�   �� *RateCommand+6�   53      �� 54   
   $ 
Horizontal=�6   $��Center=�6.   .+�55   
   �� -   5        $F @D:\БГТУ\CursachOOP\CursOOP\CursOOP\Resources\Images\Link.cur��55      $��70��6W   $��25��6b     Back#���  6n     GrayButtonStyle#��[ 6�   $��Center=�6�   $��Bottom=�6�   $��	0,0,30,30q�6  �� 56   
   $F @D:\БГТУ\CursachOOP\CursOOP\CursOOP\Resources\Images\Link.cur��6   $��70��6W   $��25��6b     Rate#���  6n     LoginButtonStyle#��[ 6�   $��Center=�6�   $��Bottom=�6�   $��0,0,0,30q�6  ��6�   �� *SubmitCommand+6  57      58      59      