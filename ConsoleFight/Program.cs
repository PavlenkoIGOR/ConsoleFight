using ConsoleApp2;

Entity player = new Entity();
Entity enemy = new Entity();

Random rndEntityTurn = new Random();
int entityTurn = rndEntityTurn.Next(0, 2);


while (player.Health >= 0 || enemy.Health >= 0)
{
    Console.Clear();
    Console.WriteLine("    Жизни: {0}              Жизни вируса: {1}", player.Health, enemy.Health);
    Console.WriteLine("    Энергия: {0}            Энергия вируса: {1}", player.Energy, enemy.Energy);
    Console.WriteLine("1. Почистить папку Temp (20 урона, -10 энергии)");
    Console.WriteLine("2. использовать антивирус (30 урона, -40 энергии)");
    Console.WriteLine("3. Выпить кофе (+20 энергии)");
    Console.WriteLine("4. Заказать доставку пиццы (+30 жизни, -20 энергии)");

    if (entityTurn == 0)
    {
        //enemy turn
        Console.WriteLine("enemy turn");
        Random rnd = new Random();
        player.Health -= rnd.Next(10, 21);
        Console.WriteLine("нанесён урон игроку 10");
        await Task.Delay(1500);
        entityTurn = 1;
    }

    else
    {//player turn
        Console.WriteLine("player turn");
        int choose = int.Parse(Console.ReadLine());
        switch (choose)
        {
            case 1:
                if (player.Energy >= 10)
                {
                    enemy.Health -= 20;
                    player.Energy -= 10;
                }
                else
                {
                    Console.WriteLine("Недостаточно энергии для выполнения действия!");
                    await Task.Delay(1500);
                }
                break;

            case 2:
                if (player.Energy >= 40)
                {
                    enemy.Health -= 30;
                    player.Energy -= 40;
                }
                else
                {
                    Console.WriteLine("Недостаточно энергии для выполнения действия!");
                    await Task.Delay(1500);
                }
                break;

            case 3:
                player.Energy += 20;
                Console.WriteLine("Вы выпили кофе и получили +20 энергии.");
                await Task.Delay(1500);
                break;

            case 4:
                if (player.Energy >= 20)
                {
                    player.Energy -= 20;
                    player.Health += 30;
                    Console.WriteLine("Вы заказали пиццу и получили +30 жизни.");
                    await Task.Delay(1500);
                }
                else
                {
                    Console.WriteLine("Недостаточно энергии для выполнения действия!");
                    await Task.Delay(1500);
                }
                break;
        }
        if (player.Energy <= 0)
        {
            Console.WriteLine("Пропуск хода. жми anykey");
            Console.ReadLine();
        }
        entityTurn = 0;
    }
    // Обработка здоровья врага
    if (enemy.Health <= 0)
    {
        Console.WriteLine("Вы победили врага!");
        Console.ReadLine();
        break; // Завершаем игру, если враг побежден
    }
    // Проверка на случай победы врага
    if (player.Health <= 0)
    {
        Console.WriteLine("Вы были побеждены врагом...");
        Console.ReadLine();
        break; // Завершаем игру, если враг побежден
    }
}