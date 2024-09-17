public class ConsoleHelp : ConsoleCommand
{
    public static ConsoleHelp instance;
    public void Awake()
    {
        try
        {
            string tab = " для быстрого удаления всех символов нажмите на клавишу Tab";
            string calculations = "\r\n\r\nдля математических операций введите calculations и знак например + после чего добавьте 2 числа пример: calculations+ 1 1, ";
            string random = "random + два числа через пробел\r\n\r\n";
            string log = "log + пробел + time для вывода времени, FPS для вывода FPS, dataPath для вывода пути до папки с игрой, identifier для Идентификационного имени, company имя компании, platform имя платформы, timeScale\r\n\r\n";
            string changer = "changer + пробел + FPS меняет FPS,gravityScale меняет у гг силу притяжения, agillity, intelligence, strength, hp, mana, movement - меняет характеристики!\r\n time меняет временную шкалу(нужно понимать что при открытии и закрытии окна консоли время уменьшается и увеличивается соответственно на 1, bpm меняет BPM сцены (дефолт 140), immortal - изменяет бессмертие\r\n\r\n";
            string spawn = "spawn + пробел + координаты от игрока + сущность - пример: spawn 1 0 Lamp - где 1 это х а 0 у и Lamp сущность\r\n Lamp призыв лампы, Platform, SlimeLord, Bat, Bird, OldGuardian, Scythe, Obelisk, DreamingDisaster - я не тестировал эту команду поэтому так что использовать ее может быть очень... Интересно :)\r\n\r\n";
            string replace = "меняет местами текстурки из игры на текстурки из вашей папки или из сайта тип файла обязан быть png - пример: replace platform https://unity3d.com/files/images/ogimg.jpg или C:\\UserName\\FolderName\\fileName.png, можно поменять lamp, circle, icon,\r\n так же можно поменять музыку, но она обязана быть mp3, для этого нужно использовать music или bossMusic - пример replace music C:\\UserName\\FolderName\\fileName.mp3\r\n\r\n";
            string application = "application + quit выход из игры, переход на другую сцену - для этого нужно использовать id сцены пример : application scene 0 - переход в главное меню, к сожелению мне впадлу пояснять за все сцены, так что просто проверьте все если хотите\r\n там есть парочка секретных тестовых локаций хз зачем они нужны были ¯\\_(ツ)_/¯\r\n\r\n";
            string end = "Это пока что все команды GL HF :)";
            instance = this;
            description = "Все команды - " + tab + calculations + random + log + changer + spawn + replace + application + end;
        }
        //https://demotivation.ru/wp-content/uploads/2020/09/vindiesel156919.jpg
        catch { }
    }
}