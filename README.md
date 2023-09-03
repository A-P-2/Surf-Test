# Surf-Test
![screenshot](https://github.com/A-P-2/Surf-Test/assets/57561034/10384eba-42d9-406f-b301-b04b05e8d619)

В папке "Surf Project" находится исходный проект с шаблоном, примерами и т.д., написанный на Unity 2022.3.8f1. 
В файле "surf-test-template.unitypackage" содержится всё тоже самое (включая примеры), так что достаточно скачать только этот файл.

## Шаблон
Функционал шаблона состоит из следующих классов:
* BasicData - абстрактный класс. Содержит поле DataName и абстрактную функцию Interact. Для работы шаблона необходимо создать класс-наследник, в котором будут содержаться все остальные поля и реализовать функцию взаимодействия с данным объектом (например, у локации - запуск сцены по ID, содержащемуся в поле sceneID). После чего, от классa-наследникa необходимо создать ScriptableObject и добавить его в папку Resources, чтобы шаблон мог загружать данные по мере необходимости.
* DataManager - класс для работы с данными. Содержит строковое поле dataPath, куда необходимо указать путь к папке с данными (из папки Resources). Функция GetListOfNames возвращает очередь из всех имён данных, а также сохраняет в словарь пары {имя : название файла с данными}. Функция GetData возвращает объект класса BasicData по указанному имени, а также сохраняет его как текущее выбранное данное. Для работы шаблона необходимо от данного класса создать ScriptableObject, указать путь к данным и передать ссылку на данный объект классу UIManager.
* InfoCard - абстрактный класс, содержащий абстрактную функцию FillInfoCard. Для работы шаблона необходимо создать класс-наследник, в котором будет реализовано заполнение UI элементов данными из объекта класса-наследника от BasicData и передать ссылку на этот компонент классу UIManager.
* UIManager - класс, реализующий работу пользовательского интерфейса. Данный класс использует переданный ему объект класса DataManager для получения списка имён, затем создаёт под каждое имя отдельную кнопку и заполняет ими указанный UI-контейнер для хранения списка имён. При нажатии одной из кнопок данный класс запрашивает у класса DataManager объект класса BasicData и передаёт его указанному объекту класса-наследника от InfoCard.
* UILoader - класс, реализующий загрузку окна по указанному пути из папки Resources

В папке Prefabs присутствует уже настроенный (настолько, насколько это возможно...) шаблон пользовательского интерфейса. Основная проблема состоит в том, что у разных данным могут быть совершенно разные поля, потому в шаблоне отсутствует панель отображения всех полей. Данную панель необходимо реализовать самостоятельно, добавить ей компонент класса-наследника от InfoCard и передать ссылку на этот объект компоненту UIManager, который привязан к главной панели.

Если нужно, чтобы главная панель загружалась в память по мере необходимости, после всех настроек нужно сохранить главную панель в виде префаба в папку Resources и указать компоненту UILoader путь к этому объекту.

В самом шаблоне отсутствует явная привязка к пользовательскому вводу. Всё управление происходит через стандартные кнопки и скроллеры, расположенные на UI. У кнопок задействуется только ивент onClick. Также, в шаблоне явно настроена навигация: вертикальная навигация (по умолчанию W/S и ↑/↓) связывает только кнопки в списке объектов, горизонтальная навигация (A/D и ←/→) позволяет переключаться между списком, скроллерами и кнопками управления (взаимодействовать и выйти).

## Примеры
В папке Examples присутвует 2 примера использования шаблона, со всеми данными, классами-наследниками, полностью настроенным UI и т.д. Там же можно найти сцену ExamplesScene, где и продемонстрирована работа обоих примеров.

Примеры реализованы те же, что указаны в тестовом задании: список персонажей и список локаций.

При запуске сцены появляется окно с 2-мя кнопками, позволяющими открыть тот или иной пример. Данное окно не является частью решения тестового задания, и просто используется как некоторое абстрактное окружение, откуда пользователь вызывает необходимые ему окна со списками (в общем, в этом окне не настроена навигация...)
