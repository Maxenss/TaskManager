   M S B A M L   `   `   `  ����F  BTaskManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:TaskManagerTaskManager  5   	   #    TaskManager.TaskManagerWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:TaskManager     5   	     � Title$#  Диспетчер задач��5   	   $	��600��6!   $	��610��6.    � 
ResizeMode$ NoResize=�6:    � Icon$A ;C:\Backup\repos\TaskManager\TaskManager\taskmanagerlogo.png��5	   	   .��5
      � .+�5   
   �� $
��Left=�6   $	��543��60   $	��Top=�6>   $	��580��6V   $��	10,10,0,0q�6b   .@�5      �� $��Очередь��6   .��5      � ���	#FFE5E5E5.+�5      &   System.Windows.Controls.DataGrid  -   5        $��dgProcessList��5         
IsReadOnly . $
��Left=�6F      AutoGenerateColumns .  $	��Top=�6}   $	��470��6�   $	��575��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��61      CanUserResize .     CanUserReorder .  	   CanUserSort	 .  
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 40 6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6~   ��  �� Path$ Id�6�     5      $ Имя��61    .   .  	 .  $
 90 6�    6   �� $
 Name�6�     5      $ Приоритет��61    .   .  	 .  $
 95 6�    6�   �� $ Priority�6�     5      $ Статус��61    .   .  	 .  $
 90 6�    6�   �� $ StatusString�6�     5      $	 RAM��61    .   .  	 .  $
 50 6�    6   �� $	 RAM�6�     5      $ 
Такты��61    .   .  	 .  $
 50 6�    6�   �� $ CountOfTactsAll�6�     5      $% Время добавления��61    .   .  	 .  $	
 150 6�    6�   �� $ TimeOfCreate�6�   5      �� 5      -   5        $ ��labelProcessesInQueueCount��5      $,��&Процессов в очереди: ��6>   $
��Left=�6^   $��372,470,0,-1q�6y   $	��Top=�6�   5      5      �� 5      $��Отклоненные��6   .��5      � ���	#FFE5E5E5.+�5        -   5        $��dgCanceledProcessList��5       . $
��Left=�6N    .  $	��Top=�6�   $	��470��6�   $	��575��6�    5        5       $ ID��61    .   .  	 .  $
 40 6�    6~   �� $ Id�6�     5!      $ Имя��61    .   .  	 .  $
 90 6�    6   �� $
 Name�6�     5"      $ Приоритет��61    .   .  	 .  $
 90 6�    6�   �� $ Priority�6�     5#      $ Статус��61    .   .  	 .  $
 95 6�    6�   �� $ StatusString�6�     5$      $	 RAM��61    .   .  	 .  $
 50 6�    6   �� $	 RAM�6�     5%      $ 
Такты��61    .   .  	 .  $
 50 6�    6�   �� $ CountOfTactsAll�6�     5&      $% Время добавления��61    .   .  	 .  $	
 150 6�    6�   �� $ TimeOfCreate�6�   5(      �� 5)      -   5        $ ��labelProcssesCanceledCount��5)      $1��+Отклоненных процессов: ��6>   $
��Left=�6`   $��372,470,0,-1q�6{   $	��Top=�6�   5*      5+      �� 5,      $��Выполненные��6   .��5-      � ���	#FFE5E5E5.+�5.        -   5        $��dgCompletedProcessList��5.       . $
��Left=�6O    .  $	��Top=�6�   $	��470��6�   $	��575��6�    5/        50      $ ID��61    .   .  	 .  $
 40 6�    6~   �� $ Id�6�     51      $ Имя��61    .   .  	 .  $
 90 6�    6   �� $
 Name�6�     52      $ Приоритет��61    .   .  	 .  $
 95 6�    6�   �� $ Priority�6�     53      $ Статус��61    .   .  	 .  $
 90 6�    6�   �� $ StatusString�6�     54      $	 RAM��61    .   .  	 .  $
 50 6�    6   �� $	 RAM�6�     55      $ 
Такты��61    .   .  	 .  $
 50 6�    6�   �� $ CountOfTactsAll�6�     56      $% Время добавления��61    .   .  	 .  $	
 150 6�    6�   �� $ TimeOfCreate�6�     57      $ Выполнен��61    .   .  	 .  $	
 150 6�    6�   �� $ TimeOfCompleted�6�   59      �� 5:      -   5        $"��labelProcessesCompletedCount��5:      $1��+Выполненных процессов: ��6@   $
��Left=�6b   $��372,470,0,-1q�6}   $	��Top=�6�   5;      5<      �� 5=      $.��(В процессе выполнения��6   .��5>      � ���	#FFE5E5E5.+�5?        -   5        $��dgExecuteProcessList��5?       . $
��Left=�6M    .  $	��Top=�6�   $	��515��6�   $	��575��6�    5@        5A      $ ID��61    .   .  	 .  $
 40 6�    6~   �� $ Id�6�     5B      $ Имя��61    .   .  	 .  $
 90 6�    6   �� $
 Name�6�     5C      $ Приоритет��61    .   .  	 .  $
 95 6�    6�   �� $ Priority�6�     5D      $ Статус��61    .   .  	 .  $
 90 6�    6�   �� $ StatusString�6�     5E      $	 RAM��61    .   .  	 .  $
 50 6�    6   �� $	 RAM�6�     5F      $ 
Такты��61    .   .  	 .  $
 50 6�    6�   �� $ CountOfTactsAll�6�     5G      $% Время добавления��61    .   .  	 .  $	
 150 6�    6�   �� $ TimeOfCreate�6�   5I      5J      5K      �� 5L      $��Ресурс 1��6   .��5M      � ���	#FFE5E5E5.+�5N      �� $
��Left=�6!   $	��495��6<   $��-1,0,0,0q�6I   $	��Top=�6[   $	��575��6s   .@�5O      �� $��Очередь��6"   .��5P      � ���	#FFE5E5E5$��10,2,4,4q�6:   .+�5Q   "     -   5        $!��dgResourceQueue1ProcessList��5Q   +    . $
��Left=�6`    .  $	��Top=�6�   $	��461��6�   $	��555��6�    5R   &     5S   *   $ ID��6=    .   .  	 .  $
 40 6�    6�   �� $ Id�6�     5T   *   $ Имя��6=    .   .  	 .  $
 90 6�    6�   �� $
 Name�6�     5U   *   $ Приоритет��6=    .   .  	 .  $
 95 6�    6�   �� $ Priority�6�     5V   *   $ Статус��6=    .   .  	 .  $
 90 6�    6�   �� $ StatusString�6�     5W   *   $	 RAM��6=    .   .  	 .  $
 50 6�    6�   �� $	 RAM�6�     5X   *   $ 
Такты��6=    .   .  	 .  $
 50 6�    6�   �� $ CountOfTactsAll�6�     5Y   *   $% Время добавления��6=    .   .  	 .  $	
 150 6�    6�   �� $ TimeOfCreate�6�   5[   #   5\      5]      �� 5^      $��Выполнение��6"   .��5_      � ���	#FFE5E5E5$��10,2,4,4q�6:   .+�5`   "     -	   5        $��dgResource1ProcessList��5`   +    . $
��Left=�6[    .  $	��Top=�6�   $	��461��6�   $	��555��6�    5a   &     5b   *   $ ID��6=    .   .  	 .  $
 40 6�    6�   �� $ Id�6�     5c   *   $ Имя��6=    .   .  	 .  $
 90 6�    6�   �� $
 Name�6�     5d   *   $ Приоритет��6=    .   .  	 .  $
 95 6�    6�   �� $ Priority�6�     5e   *   $ Статус��6=    .   .  	 .  $
 90 6�    6�   �� $ StatusString�6�     5f   *   $	 RAM��6=    .   .  	 .  $
 50 6�    6�   �� $	 RAM�6�     5g   *   $ 
Такты��6=    .   .  	 .  $
 50 6�    6�   �� $ CountOfTactsAll�6�     5h   *   $% Время добавления��6=    .   .  	 .  $	
 150 6�    6�   �� $ TimeOfCreate�6�   5j   #   5k      5l      5m      5o      5p      �� 5q      $��Ресурс 2��6   .��5r      � ���	#FFE5E5E5.+�5s      �� $
��Left=�6!   $	��495��6<   $��-1,0,0,0q�6I   $	��Top=�6[   $	��575��6s   .@�5t      �� $��Очередь��6"   .��5u      � ���	#FFE5E5E5$��10,2,4,4q�6:   .+�5v   "     -
   5        $!��dgResourceQueue2ProcessList��5v   +    . $
��Left=�6`    .  $	��Top=�6�   $	��461��6�   $	��555��6�    5w   &     5x   *   $ ID��6=    .   .  	 .  $
 40 6�    6�   �� $ Id�6�     5y   *   $ Имя��6=    .   .  	 .  $
 90 6�    6�   �� $
 Name�6�     5z   *   $ Приоритет��6=    .   .  	 .  $
 95 6�    6�   �� $ Priority�6�     5{   *   $ Статус��6=    .   .  	 .  $
 90 6�    6�   �� $ StatusString�6�     5|   *   $	 RAM��6=    .   .  	 .  $
 50 6�    6�   �� $	 RAM�6�     5}   *   $ 
Такты��6=    .   .  	 .  $
 50 6�    6�   �� $ CountOfTactsAll�6�     5~   *   $% Время добавления��6=    .   .  	 .  $	
 150 6�    6�   �� $ TimeOfCreate�6�   5�   #   5�      5�      �� 5�      $��Выполнение��6"   .��5�      � ���	#FFE5E5E5$��10,2,4,4q�6:   .+�5�   "     -   5        $��dgResource2ProcessList��5�   +    . $
��Left=�6[    .  $	��Top=�6�   $	��461��6�   $	��555��6�    5�   &     5�   *   $ ID��6=    .   .  	 .  $
 40 6�    6�   �� $ Id�6�     5�   *   $ Имя��6=    .   .  	 .  $
 90 6�    6�   �� $
 Name�6�     5�   *   $ Приоритет��6=    .   .  	 .  $
 95 6�    6�   �� $ Priority�6�     5�   *   $ Статус��6=    .   .  	 .  $
 90 6�    6�   �� $ StatusString�6�     5�   *   $	 RAM��6=    .   .  	 .  $
 50 6�    6�   �� $	 RAM�6�     5�   *   $ 
Такты��6=    .   .  	 .  $
 50 6�    6�   �� $ CountOfTactsAll�6�     5�   *   $% Время добавления��6=    .   .  	 .  $	
 150 6�    6�   �� $ TimeOfCreate�6�   5�   #   5�      5�      5�      5�      5�      �� 5�      $��Ресурс 3��6   .��5�      � ���	#FFE5E5E5.+�5�      �� $
��Left=�6!   $	��495��6<   $��-1,0,0,0q�6I   $	��Top=�6[   $	��575��6s   .@�5�      �� $��Очередь��6"   .��5�      � ���	#FFE5E5E5$��10,2,4,4q�6:   .+�5�   "     -   5        $!��dgResourceQueue3ProcessList��5�   +    . $
��Left=�6`    .  $	��Top=�6�   $	��461��6�   $	��555��6�    5�   &     5�   *   $ ID��6=    .   .  	 .  $
 40 6�    6�   �� $ Id�6�     5�   *   $ Имя��6=    .   .  	 .  $
 90 6�    6�   �� $
 Name�6�     5�   *   $ Приоритет��6=    .   .  	 .  $
 95 6�    6�   �� $ Priority�6�     5�   *   $ Статус��6=    .   .  	 .  $
 90 6�    6�   �� $ StatusString�6�     5�   *   $	 RAM��6=    .   .  	 .  $
 50 6�    6�   �� $	 RAM�6�     5�   *   $ 
Такты��6=    .   .  	 .  $
 50 6�    6�   �� $ CountOfTactsAll�6�     5�   *   $% Время добавления��6=    .   .  	 .  $	
 150 6�    6�   �� $ TimeOfCreate�6�   5�   #   5�      5�      �� 5�      $��Выполнение��6"   .��5�      � ���	#FFE5E5E5$��10,2,4,4q�6:   .+�5�   "     -   5        $��dgResource3ProcessList��5�   +    . $
��Left=�6[    .  $	��Top=�6�   $	��461��6�   $	��555��6�    5�   &     5�   *   $ ID��6=    .   .  	 .  $
 40 6�    6�   �� $ Id�6�     5�   *   $ Имя��6=    .   .  	 .  $
 90 6�    6�   �� $
 Name�6�     5�   *   $ Приоритет��6=    .   .  	 .  $
 95 6�    6�   �� $ Priority�6�     5�   *   $ Статус��6=    .   .  	 .  $
 90 6�    6�   �� $ StatusString�6�     5�   *   $	 RAM��6=    .   .  	 .  $
 50 6�    6�   �� $	 RAM�6�     5�   *   $ 
Такты��6=    .   .  	 .  $
 50 6�    6�   �� $ CountOfTactsAll�6�     5�   *   $% Время добавления��6=    .   .  	 .  $	
 150 6�    6�   �� $ TimeOfCreate�6�   5�   #   5�      5�      5�      5�      5�      �� 5�      $��Сервис��6   .��5�      � ���	#FFE5E5E5.+�5�      �� -   5        $��btGenerateTProcess��5�      $8��2Сгенерировать один процесс��67   $
��Left=�6\   $��
177,52,0,0q�6w   $	��Top=�6�   $	��209��6�   6�   �� 5�      -   5         ��Name$ btGenerate10TProcess��5�      $@��:Сгенерировать десять процессов��6;   $
��Left=�6d   $��
177,90,0,0q�6   $	��Top=�6�   $	��209��6�   6�   �� 5�      -   5        $ btGenerate100TProcess��5�      $:��4Сгенерировать сто процессов��6<   $
��Left=�6b   $��177,129,0,0q�6}   $	��Top=�6�   $	��209��6�   6�   �� 5�      $2��,Сведения об устройстве: ��6   $
��Left=�6?   $��209,176,0,0q�6Z   $	��Top=�6o   �� 5�      -   5         ��Name$ labelCountRAM��5�      $+��%Общее количество RAM: ��63   $
��Left=�6T   $��177,207,0,0q�6o   $	��Top=�6�   �� 5�      -   5        $ labelCountRAMFree��5�      $3��-Свободное количество RAM: ��67   $
��Left=�6\   $��177,233,0,0q�6w   $	��Top=�6�   �� 5�      -   5        $ labelCountRAMUsed��5�      $$��Использовано RAM: ��67   $
��Left=�6T   $��177,259,0,0q�6o   $	��Top=�6�   �� 5�      -   5        $ labelCPUFreq��5�      $+��%Частота процессора: ��62   $
��Left=�6Q   $��177,285,0,0q�6l   $	��Top=�6�   �� 5�      -   5        $ btSetConfig��5�      $/��)Изменить конфигурацию��62   $
��Left=�6R   $��177,331,0,0q�6m   $	��Top=�6�   $	��209��6�   6�   �� 5�      -   5        $��labelDelayCompleted��5�      $=��7Среднее время для выполнения: ��67   $
��Left=�6`   $��
45,378,0,0q�6{   $	��Top=�6�   �� 5�      -   5        $ labelDelayToStart��5�      $J��DСреднее время для начала выполнения: ��67   $
��Left=�6g   $��
45,409,0,0q�6�   $	��Top=�6�   �� 5�      $2��,Сведения об устройстве: ��6   $
��Left=�6?   $��209,176,0,0q�6Z   $	��Top=�6o   5�      5�      5�      5�      5�      