using Zenject;

public class GameInstaller : MonoInstaller
{
    public ClickerSettingsData clickerSettingsData;
    public TextClick textClickPrefab;
    public FactsItem factsItemPrefab;

    public override void InstallBindings()
    {
        BindScriptableObject();

        BindPrefabs();

        BindLogic();
    }

    private void BindScriptableObject()
    {
        Container.Bind<ClickerSettingsData>().FromInstance(clickerSettingsData).AsSingle();
    }

    private void BindPrefabs()
    {
        Container.Bind<TextClick>().FromInstance(textClickPrefab).AsSingle();

        Container.Bind<FactsItem>().FromInstance(factsItemPrefab).AsSingle();
    }

    private void BindLogic()
    {
        Container.Bind<Money>().FromInstance(new())
            .AsSingle()
            .OnInstantiated((InjectContext ctx, Money money) => money.Init());

        Container.Bind<Energy>().FromComponentInHierarchy().AsSingle();

        Container.Bind<ClickHandler>().FromComponentInHierarchy().AsSingle();

        Container.Bind<Ui>().FromComponentInHierarchy().AsSingle();

        Container.Bind<Hud>().FromComponentInHierarchy().AsSingle();

        Container.Bind<RequestQueueManager>().FromComponentInHierarchy().AsSingle();

        Container.Bind<FactsRequest>().FromComponentInHierarchy().AsSingle().NonLazy();

        Container.Bind<AudioManager>().FromComponentInHierarchy().AsSingle();
    }
}