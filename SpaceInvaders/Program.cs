// See https://aka.ms/new-console-template for more information
using SpaceInvaders;
using SpaceInvaders.Objects;

GameEngine gameEngine;
UIController controller;

Initialize();

CancellationTokenSource tokenSource = new CancellationTokenSource();

CancellationToken cancellationToken = tokenSource.Token;

Task uiThread = new Task(controller.StartListen, cancellationToken);

uiThread.Start();

gameEngine.Run();

tokenSource.Cancel();

Console.ReadKey();

void Initialize()
{
    Thread.CurrentThread.Priority = ThreadPriority.AboveNormal;

    GameSettings gameSettings = new GameSettings();

    gameEngine = GameEngine.GetGameEngine(gameSettings);

    controller = new UIController();

    controller.OnArrowRightPress += (obj, args) => gameEngine.PlayerShipMoveRight();

    controller.OnArrowLeftPress += (obj, args) => gameEngine.PlayerShipMoveLeft();

    controller.OnQPress += (obj, args) => gameEngine.QuitGame();

    controller.OnSpacePress += (obj, args) => gameEngine.PlayerShipShot();

    controller.OnPPress += (obj, args) => gameEngine.PauseGame();
}


