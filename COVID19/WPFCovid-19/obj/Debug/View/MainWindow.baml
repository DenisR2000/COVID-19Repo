   M S B A M L   `   `   `  ����F  BWPFCovid-19, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WPFCovid_19WPFCovid_19  5   	       WPFCovid_19.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5   	   %localclr-namespace:WPFCovid_19  5   	     � Title$  Covid-19��5	   	   $	��450��6   $	��800��6'    � WindowStyle$ 
ToolWindow=�63    � 
ResizeMode$ NoResize=�6L    � 	Resources 5       �� 
TargetType �� Property �� Value��%�   '�       '_� P     �� 5   
   " �6   .�5      ��  �@J�	AllowDrop . 6*   5      �� 5   
   " _�6   .�5      ��  � �� �#5dadb36+   �� 5       � ��
 �����6+   �� 5       � |� . 6*   5      5      .��5      � .+�5   
   �� -   5         ��Name$ btGlobal��5      $��	Confirmed��6#   $
��Left=�6i   $��10q�6�   $��35��6�   $��Center=�6�   ��67   �� *ShowStatisticsConformdCommand+ � ToolTip 5      _� 5      
����ح�
�������.��5      �� $#��Сonfirmed cases in countries��6    6F   5      5      &   System.Windows.Controls.DataGrid  5   
   -   5        	  Name$	 gridInCityes��5      
   SelectionMode$
 Extended=�5      $y�Visible=�5       $��10q�5!      $��1��5"      $��1��5#      ���#bafaff��5%      �� *GridStatisticsInCountry+��5&      ��  �� ElementName$ Video����5'      �� $ Video�� 5(      ��%+   '��       �� 5)      " ��6   5*      5+      *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5,      +  %Microsoft.Xaml.Behaviors.EventTrigger  5.         	EventName$ MouseDoubleClick��6!   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5/      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6,   �� *
DoubleClic+   CommandParameter 50      �� $ gridInCityes�� �� Path$ SelectedItem�51      54      r� 55   
   -   5         r�Name$ Video��55       r� Source$ 718.mp4?�6&   $	��350��67   $��1��6D   $��1��6T   $��10q�6a   y�6m   �� *	ShowVodeo+6�     56   
   -   5        $	 	gridfirst��5:      $��10q�57      $��1��58      $��0��59         AlternatingRowBackground
 ����� �� AlternationCount$ 2��5<         AutoGenerateColumns .  
�������   
IsReadOnly . $
 Extended=�5@   7   ��6   �� *GridTotalConfirmd+   Columns 5A      0  *System.Windows.Controls.DataGridTextColumn  5B      ,  &System.Windows.Controls.DataGridColumn   Header$ Country��6A   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *	Country+   	CellStyle 5C      �� 5D      *	  $System.Windows.Controls.DataGridCell" 	 6    .�5E      ��  �@�ToolTip 68   �� *	Country+5F      5H        5I      $ Total confirmed��6Q    6%   �� *TotalConfirmedInCountry+6l     5J      $ New total confirmed��6O    6%   �� *NewConfirmedInCountry+6n    5L      ��%"   '��       �� 5M      " ��6   5N       5O        5P      $ MouseUp��6!   . 5Q         6,   �� *ItemSelectionChanged+ 5R      �� $ 	gridfirst��$ SelectedItem�5S      5U      �� 5V   
   $��1��6   $��0��6%    �� Orientation$ 
Horizontal=�62   .+�5W      o� $
��Left=�6   $
��auto��6.   .@�5X      m� $��
Statistics��6   .@�5Y      m� $ ��Total Confirmed In Country��6    m� Command 6C   �� *SortByTotalConfirmedInCountry+6w   5Z      5[      �� 5\      -   5        $
 Shov��5\      $��15q�6#   $��Center=�60   $
��Left=�6K   $$��Fonts/#Dosis-VariableFont_wght)�6f   $��Show in citys��6�   ��6�   �� *ShowStatisticsCommand+5]      �� 5^   
   $��1��6   $��5q�6$   
����� �68    � ColumnDefinitions 5_   
   �� 5`      $	��300 �6   �� 5a       � RowDefinitions 5c   
   �� 5d      $��50 �6   6*   �� 5e      6   5h      5i      