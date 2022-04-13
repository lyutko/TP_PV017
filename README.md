# The team project for the command work training
### *Підготовка*

1. Для початку треба скопіювати репозиторій. В Git-bash виконати команду:  
        `git clone https://github.com/lyutko/TP_PV017.git`
2. Налаштувати репозиторій:  
    2.1. Відкрити папку, яка утворилась та встановити ім'я користувача та електронну пошту, виконавшити наступні команди:  
        `git config --local user.name "Name"`  
        `git config --local user.email "email@gmail.com"`

    > Тут замість  **`Name`**  та  **`email@gmail.com`**  вказасти свої значення.  
    > Також при бажанні можна використати **`--global`** замість **`--local`** для збереження для всього комп'ютера, а не лише для проекту.

    2.2. Перевірити доступ до проекту:  
    2.2.1. Створити окрему гілку.  
        `git checkout -b  surname`  
    > Тут замість **`surname`** вказати своє прізвище. Це і буде назвою нової гілки.  
    > ***Важливо:*** В подальшому для кожної задачі має бути створена окрема гілка!

    2.2.2. Зробити тестовий коміт.  
    Для цього у кінці файлу **`README.md`**, у розділі `Учасники проекту`, вписати своє прізвище та ім'я.
    Потім виконати наступні команди:  
        `git add .`  або `git add *`  
        `git commit -m "Connection test"`  
		
	2.2.3. Перевірити з'єднання.  
    Для цього виконати команду:  
        `git push origin  surname` 

    > Тут замість **`surname`** вказати назву своєї гілки, створеної в пункті ***'2.2.1'*** (тобто має бути своє прізвище).  

    > Під час появи повідомлення про авторизацію, обрати за допомогою браузера, та ввести логін (електронну пошту) та пароль, що використовуються для авторизації на сайті [github.com](https://github.com).  

    2.2.4. Перевірити появу своєї гілки у [репозиторії на github](https://github.com/lyutko/TP_PV017).

3. На сайті [репозиторію проекту TP_PV017](https://github.com/lyutko/TP_PV017) створити пул-реквест щодо створених змін в пункті ***'2'***.


### *Завдання*
1. Реалізувати програму для обліку персональних фінансів користувачів, дані якої будуть зберігатись на сервері. Програма повинна підтримувати наступні можливості:  
    a. Клієнт-серверна програма  
    b. Авторизація користувачів  
    c. Кілька валют  
    d. Кілька гаманців  
    e. додавання/видалення джерел доходу  
    f. додавання/видалення категорій витрат  
    g. облік витрат та доходів  
    h. перегляд доходів та витрат за певний період часу у вигляді звітів/графіків  

2. Кожного дня у файлі **`Daily_meetings.md`** заповняти дані навпроти свого імені.


### *Учасники проекту*

1. Movchanets Viacheslav
2. Potapchuk Dmytro
3. Пасічник Михайло
4. Artem Feskov


