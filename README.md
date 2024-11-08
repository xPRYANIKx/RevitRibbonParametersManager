# RevitRibbonParametersManager
## batchAddingParameters
<p align="center">
  <img src="https://github.com/user-attachments/assets/cd17bf78-9939-451b-a4d1-a9a886fe1780">
</p>  

Данный плагин для **Autodesk Revit** позволяет автоматизировать процесс добавления параметров и их значений в семейства, используя для этих целей json-файл с преднастройками.
Пользователь может легко создавать этот json-файл непосредственно в плагине, где он настраивает необходимые конфигурации. 
Плагин поддерживает добавление как параметров из **"Файла общих параметров"** (ФОП), так и параметров, созданных пользователем.   
Кроме того, данный плагин предоставляет пользователю возможность добавления параметров и их значений сразу в несколько семейств, что существенно ускоряет процесс настройки семейств и повышает гибкость проектирования.

### Важная информация
1. Плагин поддерживает работу как с более старыми, так и с новыми версиями **Autodesk Revit**. Поэтому в файле [**RevitRibbonParametersManager.csproj**](https://github.com/xPRYANIKx/RevitRibbonParametersManager/blob/main/RevitRibbonParametersManager.csproj) предусмотрены две вариации компиляции: 
**"Revit2020"** и **"Revit2023"** _(используется для версий от 2021)_, каждая из которых имеет свои собственные пути вывода _("OutputPath")_ и константы определения _("DefineConstants")_.
2. Файл [**Forms/batchAddingParametersWindowСhoice.xaml.cs**](https://github.com/xPRYANIKx/RevitRibbonParametersManager/blob/main/Forms/batchAddingParametersWindow%D0%A1hoice.xaml.cs) содержит в себе методы с именами вариаций параметра **"Тип/Экземпляр"** _("CreateTypeInstanceList")_, 
именами типов данных параметров _("GetParameterTypeFromString")_, именами вариаций группирования _("CreateGroupingDictionary")_, а также различные методы соотношения типа данных _("RelationshipOfValuesWithTypesToAddToParameter" и "CheckingValueOfAParameter")_, которые ориентированны на российскую локализацию программы.
Если вы используете другую версию локализации **Autodesk Revit** - вам необходимо изменить string-значения имён параметров и имён типов данных в интерфейсе для этих методов.
3. К сожалению, данный плагин не позволит пользователю создать или добавить параметр из **"Файла общих параметров"** типа **"FamilyType"**, а также не даст добавить значение в параметр типа **"LoadClassification"**. 
4. Обратите внимание, что в более новых версиях **Autodesk Revit** появились параметры и варианты группирования, которые отсутствуют в старых версиях. В таких случаях плагин выдаст предупреждение о несовместимости версий.
5. Для создания Ribbon-панели в плагине используется библиотека [**VCRevitRibbonUtil**](https://github.com/chekalin-v/VCRevitRibbonUtil). Однако при необходимости вы можете реализовать эту функциональность самостоятельно, используя официальную документацию.     

---
### Принцип работы  
<p align="center">
  <img src="https://github.com/user-attachments/assets/ce136d74-f1a0-4ca6-a030-fd1f93cfa469">
</p>  

1. **Имя выбранного семейства**. Если семейство не выбрано - то указывается, что семейство не выбрано и все кнопки кроме **"Использовать готовый файл-конфигурации для нескольких семейств"** становятся недоступны.
2. **Пакетное добавление общих параметров**. Позволяет добавить параметры из **"Файла общих параметров"**, а также сохранить json-файл с преднастройками для этих параметров, чтобы использовать данный файл в будущем.
3. **Пакетное добавление параметров семейства**. Позволяет добавить созданные пользователем параметры, а также сохранить json-файл с преднастройками для этих параметров, чтобы использовать данный файл в будущем.
4. **Использовать готовый файл-конфигурации**. Пользователь загружает json-файл с преднастройками, и в зависимости от содержимого этого файла открывается окно **"Пакетное добавление общих параметров"** или **"Пакетное добавление параметров семейства"**. Если плагину не удастся прочитать json-файл с преднастройками или файл окажется испорченным - будет выведено сообщение об ошибке.
5. **Использовать готовый файл-конфигурации для нескольких семейств**. Пользователь выбирает json-файл с преднастройками и указывает ссылки на семейства, в которые необходимо внести параметры из json-файла.

---
### Пакетное добавление общих параметров
<p align="center">
  <img src="https://github.com/user-attachments/assets/9ab89aee-0db5-4a62-b2b8-e9f599408629">
</p>  

**1** - Имя выбранного семейства.  

**2** - Ссылка на выбранный **"Файл общих параметров"**. Нельзя указывать вручную, только через кнопку **"Заменить"** (2.1).  

> **Важно:** пользователь не сможет выбрать новый **"Файл общих параметров"** пока не будут заполнены поля "Группа" и "Параметр" у добавленных ранее параметров.
 
> **Важно:** после выбора нового **"Файла общих параметров"** пользователь не сможет редактировать поля "Группа" и "Параметр" у добавленных ранее параметров.

**3.1** - Выбор группы параметров [ComboBox]. 

**3.2** - Выбор параметра [ComboBox/TextBox].   

> **Примечание:** пользователь может начать вводить текст в поле **"Параметр"** для поиска необходимого параметра в **"Файле общих параметров"**. Если параметр был найден - то поле “Группа” (3.1) заполняется автоматически.

**3.3** - Выбор **"Тип/Экземпляр"** [ComboBox].  

**3.4** - Выбор вариаций группирования [ComboBox].  

**3.5** - Значение параметра [TextBox].  

> **Примечание:** пользователь может начать вводить текст в поле **"Параметр"** для поиска необходимого параметра в **"Файле общих параметров"**. Если параметр был найден - то поле “Группа” (3.1) заполняется автоматически.

Поле может иметь 4 цветовых индикатора, которые указывают на статус введённого значения:
* Жёлтый фон - значение не введено. Параметр добавляется в семейство без заполненного значения.
* Зелёный фон – введено верное значение. Параметр добавляется в семейство с заполненным значением.
* Синий фон – невозможно проверить значение параметра _(используется тип данных “Image” или формула)_. Параметр добавляется в семейство с заполненным значением, но может отобразиться окно с ошибкой.
* Красный фон - введено неверное значение. Нельзя добавить параметр в семейство.

> **Примечание:** чтобы добавить формулу в параметр, необходимо, чтобы значение начиналось с симовала "=".  
Если значение имеет тип данных "Text", то оно должно быть обрамлено в кавычки _(например: ="simple")_.

> **Примечание:** чтобы добавить значение типа "Image" - необходимо указать ссылку на изображение _(на локальном диске)_ в формате **"[Буква диска]:\\Имя_папки\\изображение.расширение".**

> **Примечание:** чтобы добавить значение типа "Material" - необходимо указать имя материала.

> **Важно:** начиная с **Autodesk Revit 2021** все числовые значения, а также **FamilyType** попадают в необработанную группу **"Autodesk.Revit.DB.ForgeTypeID"**. В данных версиях **FamilyType** также недоступен для добавления.

**3.6** - Удалить параметр из интерфейса.  

**4** - Добавить параметр в интерфейс.

**5** - Добавить параметры в семейство.

> Важно: если имя параметра, который мы хотим добавить, совпадает с именем уже существующего параметра, то параметр не перезаписывается, а обновляет своё значение.

> **Примечание:** в случае если мы попытаемся добавить одинаковые параметры или неправильно заполненные значения параметров - выведется диалоговое окно с предупреждением. Если параметры будут добавлены с ошибками - пользователю будет предложено сохранить отчёт об ошибках.

**6** - Сохранить json-файл преднастроек.    

> **Примечание:** в случае если мы попытаемся сохранить файл преднастроек с одинаковыми параметрами или неправильно заполненными значения параметров - выведется диалоговое окно с предупреждением.

---
### Пакетное добавление параметров семейства
<p align="center">
  <img src="https://github.com/user-attachments/assets/4b57f8f1-29eb-4e81-b94f-c07c2c86b1f5">
</p>  

**1** - Имя выбранного семейства.  

**2.1** - Количество одинаковых параметров, которое будет создано [TextBox]. 

> **Важно:** диапазон допустимых значений от "1" до "100",

> **Важно:** если выбрано отличное от "1" значение, то название формируется по принципу - **Имя(Порядковый номер)**; если выбрано значение “1”, то числовая подпись не указывается;

> **Примечание:** по умолчанию в данном поле установлено значение “1”.

**2.2** - Имя параметра [TextBox]. 

**2.3** - Выбор **"Тип/Экземпляр"** [ComboBox].  

**2.4** - Выбор категории типа данных параметра [ComboBox].  

**2.5** - Выбор типа данных параметра, соответствующий категории из **2.4** [ComboBox].  

**2.6** - Выбор вариаций группирования [ComboBox].  

**2.7** - Значение параметра [TextBox].  

Поле может иметь 4 цветовых индикатора, которые указывают на статус введённого значения:
* Жёлтый фон - значение не введено. Параметр добавляется в семейство без заполненного значения.
* Зелёный фон – введено верное значение. Параметр добавляется в семейство с заполненным значением.
* Синий фон – невозможно проверить значение параметра _(используется тип данных “Image” или формула)_. Параметр добавляется в семейство с заполненным значением, но может отобразиться окно с ошибкой.
* Красный фон - введено неверное значение. Нельзя добавить параметр в семейство.

> **Примечание:** чтобы добавить формулу в параметр, необходимо, чтобы значение начиналось с симовала "=".  
Если значение имеет тип данных "Text", то оно должно быть обрамлено в кавычки _(например: ="simple")_.

> **Примечание:** чтобы добавить значение типа "Image" - необходимо указать ссылку на изображение _(на локальном диске)_ в формате **"[Буква диска]:\\Имя_папки\\изображение.расширение".**

> **Примечание:** чтобы добавить значение типа "Material" - необходимо указать имя материала.

> **Важно:** начиная с **Autodesk Revit 2021** все числовые значения, а также **FamilyType** попадают в необработанную группу **"Autodesk.Revit.DB.ForgeTypeID"**. В данных версиях **FamilyType** также недоступен для добавления.

**2.8** - Указать текст всплывающей подсказки [TextBox].    

**2.9** - Удалить параметр из интерфейса.   

**3** - Добавить параметр в интерфейс.

**4** - Добавить параметры в семейство.

> Важно: если имя параметра, который мы хотим добавить, совпадает с именем уже существующего параметра, то параметр не перезаписывается, а обновляет своё значение.

> **Примечание:** в случае если мы попытаемся добавить одинаковые параметры или неправильно заполненные значения параметров - выведется диалоговое окно с предупреждением. Если параметры будут добавлены с ошибками - пользователю будет предложено сохранить отчёт об ошибках.

**5** - Сохранить json-файл преднастроек.    

> **Примечание:** в случае если мы попытаемся сохранить файл преднастроек с одинаковыми параметрами или неправильно заполненными значения параметров - выведется диалоговое окно с предупреждением.

---
### Использовать готовый файл-конфигурации для нескольких семейств
<p align="center">
  <img src="https://github.com/user-attachments/assets/eb8b98e8-e01d-4fd6-bb98-9ec1a5bfa853">
</p>  

**1** - Тип параметров из json-файла с преднастройками.  

**2** - Ссылка на json-файл с преднастройками [TextBox]. 

**3** - Кнопка **"Открыть"**. Открывает json-файл с преднастройками. 

> **Важно:** после открытия json-файл с преднастройками недоступные кнопки интерфейса становятся доступными.

> **Важно:** после открытия json-файл с преднастройками выбрать новый json-файл уже нельзя.

**4.1** - Ссылка на файл семейства [TextBox]. 

**4.2** - Открытие окна для выбора файла/файлов семейства. 

**4.3** - Удаление выбранного семейства. 

**5** - Добавить семейство в интерфейс.

**6** - Добавление параметров из json-файл с преднастройками в выбранные семейства.

> Важно: если имя параметра, который мы хотим добавить, совпадает с именем уже существующего параметра, то параметр не перезаписывается, а обновляет своё значение.

> **Примечание:** после нажатия на кнопку **"Добавить параметры в семейство"** незаполненные поля будут удалены.

> **Примечание:** в случае, если мы попытаемся добавить параметры в одно и тоже семейство несколько раз - выведется диалоговое окно с предупреждением. Если параметры будут добавлены с ошибками - пользователю будет предложено сохранить отчёт об ошибках.
