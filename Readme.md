# Тестовые задания
## Задание 1
   Дано: генеалогическое дерево семьи. Дерево представлено в виде форматированного списка и хранится в текстовом файле. Дерево отформатировано при помощи отступов слева символами [Tab].
Каждая запись дерева имеет формат:
Полное имя | Пол | Год рождения
•	В списке нет повторяющихся имен;
•	Пол всегда представлен буквами М или Ж;
•	Год – всегда целое четырехзначное число;
•	Элементы списка разделяются вертикальной чертой;
Пример файла:
Иван Андреевич | М | 1738
[Tab] Петр Иванович | М | 1756
[Tab] [Tab] Глафира Петровна | М | 1777
[Tab] [Tab] Анна Петрова | М | 1780
[Tab] Дарья Ивановна | Ж | 1758
[Tab] [Tab] Иван Николаевич | М | 1780
[Tab][Tab] [Tab] Иван Иванович | М | 1805
[Tab][Tab] [Tab] Никифор Иванович | М | 1812
……
[Tab][Tab] Афанасий Николаевич | М | 1784
[Tab][Tab][Tab] Яков Афанасиевич | М | 1783
[Tab][Tab][Tab] Павел Афанасиевич | М | 1805
[Tab][Tab][Tab] Екатерина Афанасиевна | М | 1808
……
итд.

Задание: напишите программу. Программа должна принимать запросы с консоли, каждый запрос должен содержать:
•	имя члена семьи;
•	тип родства Б или С - брат или сестра;
•	степень родства – целое число, где 1 – родной брат или сестра, 2- двоюродный и тд;
В ответ программа должна выводить список всех родственников, попадающих под это условие.
Пример:
Запрос: Иван Иванович, тип родства Б, степень родства 1
Ответ: Никифор Иванович
Запрос: Иван Иванович, тип родства Б, степень родства 2
Ответ: Яков Афанасиевич, Павел Афанасиевич
Дополнительно задание: обратите внимание, в файле могут содержаться неверные даты рождения, например, Яков Афанасиевич, 1783 не мог родиться раньше своего отца Афанасия Николаевича, 1784. Найдите все ошибки.

### Особенности реализации
Принято, что на каждой строке хранится запись только об одном человеке, а поколение определяется количеством табуляций.
Поскольку не было уточнено, принято решение что путь к файлу будет указываться в ручную. 
Файл на котором производилось тестирования лежит в папке проекта - TestIssue1
### Prerequirements
.NET Core 3 и выше

## Задание 2
Требования:
Реализовать на NetCore любой версии
Использовать инжекцию зависимостей для работы с ReportBuilder и Reporter
Использовать Task для реализации асинхронности

Задание:
Написать приложение на Net Core, публикующее Web API из двух методов
Метод BUILD:
HTTP метод: GET.   
Без параметров. 
Возвращает целое: ID запроса на построение отчета.
Метод STOP: 
HTTP метод: POST. 
Принимает в теле запроса целое число: ID запроса на построение отчета, выданное ранее методом BUILD

Программа содержит классы:
Класс ReportBuilder, реализует интерфейс IReportBuilder
Методы:
•	public byte[] Build(). Возвращает массив, содержащий отчет. Эмулирует построение отчета:  ожидает случайное время от 5 до 45 секунд, после чего записывает в массив байты строки «Report ready at [s] s.» (UTF-8) и возвращает запененный массив, где [s] – время построения отчета. С вероятностью 20% после ожидания выкидывает исключение: throw new Exception(“Report failed“). Ожидание реализовать как цикл от 5 до 45 раз усыпляющий поток на 1 секунду.

Класс Reporter, реализует интерфейс IReporter
Методы:
•	public void ReportSuccess(byte[] Data, int Id). Записывает в файл с именем Report_[Id]. txt  байты из Data. Где [Id] – значение аргумента Id.
•	public void ReportError( int Id).  Записывает в файл с именем Error_[Id]. txt  текст «Report error». Где [Id] – значение аргумента Id.
•	public void ReportTimeout( int Id).  Записывает в файл с именем Timeout_[Id]. txt  текст «Report error». Где [Id] – значение аргумента Id.

Работа приложения:
Web vетод BUILD должен запустить метод Build класса ReportBuilder, присвоить запросу на построение отчета номер, и вернуть в качестве ответа. Номера назначать последовательно начиная от нуля.
Если метод Build завершился успешно менее чем за 30 секунд, должен быть вызван метод ReportSuccess класса Reporter, куда передан результат работы Build.
Если метод Build выкинул исключение, должен быть вызван метод ReportError класса Reporter.
Если метод Build не был выполнен за 30 секунд, должен быть вызван метод ReportTimeout класса Reporter, выполнение метода Build должно быть прекращено.

Web метод STOP должен остановить построение соответствующего отчета.

Реализовать на NetCore любой версии
Использовать инжекцию зависимостей для работы с ReportBuilder и Reporter
Использовать Task для асинхронности

## Особенности реализации
Поскольку не было сказано обратного, принято что количество одновременно формируемых отчётов равно одному.
Для облегчения просмотра и отладки подключена библиотека swagger, через которую производились запросы к API.
Текстовые файлы Report записываются в папку TestIssue2.
Отмена задачи реализована через CancellationToken.

## Prerequirements
.NET версии 5 и выше.
