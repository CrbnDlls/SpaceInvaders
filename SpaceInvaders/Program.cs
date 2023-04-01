using SpaceInvaders;

GameEngine? gameEngine;
UIController controller;
GameSettings gameSettings;

bool gameRunning = true;

CancellationTokenSource tokenSource = new CancellationTokenSource();

CancellationToken cancellationToken = tokenSource.Token;

Initialize();

void Initialize()
{
    Thread.CurrentThread.Priority = ThreadPriority.AboveNormal;

    gameSettings = new GameSettings();

    gameEngine = GameEngine.GetGameEngine(gameSettings);

    controller = new UIController();

    controller.OnQPress += QuitGame;
    controller.OnEscapePress += QuitGame;
    controller.OnArrowRightPress += (obj, args) => gameEngine.PlayerShipMoveRight();
    controller.OnArrowLeftPress += (obj, args) => gameEngine.PlayerShipMoveLeft();
    controller.OnSpacePress += (obj, args) => gameEngine.PlayerShipShot();
    controller.OnPPress += (obj, args) => gameEngine.PauseGame();
    controller.OnEnterPress += (obj, args) => gameEngine.EndGame();

    Task uiThread = new Task(controller.StartListen, cancellationToken);
    uiThread.Start();

    do
    {
        gameEngine.Initialize();

        gameEngine.Run();

        if (gameRunning)
        {
            Console.WriteLine("Press any key to continue...");

            Console.ReadKey(true);
        }

    } while (gameRunning);
}

void QuitGame(object sender, EventArgs e)
{
    tokenSource.Cancel();
    gameRunning = false;
    gameEngine?.EndGame();
}