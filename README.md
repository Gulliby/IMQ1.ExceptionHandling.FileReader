# IMQ1.ExceptionHandling.FileReader

**1.Класс FileReader**

Разработать класс FileReader, который содержит метод(-ы) Read, принимающий(-ие) следующие параметры:

FilePath – путь к файлу, обязательный параметр
StartPosition – номер символа, с которого начинается считывание, необязательный (если не задан, файл считывается с начала)
Length – длина считываемой подстроки (или до конца файла, если имеет место выход за пределы файла), необязательный (если не задан, считывать файл до конца)
В результате метод Read должен вернуть считанную подстроку.

Для класса FileReader предусмотреть следующие случаи:

Ошибки пользователя – файл не существует по пути FilePath, StartPosition выходит за пределы файла, файл имеет недопустимое расширение (список расширений конфигурировать через конфигурационный файл или как массив констант – в данной задаче это не принципиально). Для ошибок пользователя создать собственный класс исключений
Системные ошибки – FileReader в 30% случаев должен бросать исключение, что reader сейчас недоступен. Для этого следует разработать еще один собственный класс исключений. Для того, чтобы смоделировать 30% случаев системных ошибок, можно воспользоваться классом Random для генерации случайного числа, например, от 1 до 10. И, если выпадают числа 1..3, то выбрасывается исключение
 

**2.Класс Logger**

Разработать класс Logger, который ассоциируется с некоторым файлом на диске. В классе определить один метод Log, принимающий параметры Message и Exception. В результате вызова этого метода в файле логирования должны быть сохранены:

Пользовательское сообщение (Message)
Сообщение исключения (Message)
Стек трейс исключения (Exception.StackTrace)
Также следует предусмотреть случай, когда Exception содержит значение в InnerException, который также может содержать в себе InnerException и т.д. В конечном итоге, все данные из Exception и InnerException должны быть сохранены

 

**3.Консольный интерфейс**

Разработать консольное приложение, которое запрашивает у пользователя необходимые параметры и запускает процесс извлечения подстроки из файла с помощью FileReader. Если операция прошла успешно, то полученная подстрока отображается пользователю на экране.

Если возникла ошибка пользователя, то записать ошибку в файл логирования с использованием класса Logger, а также вывести сообщение об ошибке на экран.

В случае системной ошибки приложение должно выполнять повторный запрос к файлу до тех пор, пока операция не закончится успешно, или не возникнет исключение другого, не системного типа.