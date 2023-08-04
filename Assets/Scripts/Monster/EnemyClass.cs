
public class EnemyClass
{
    protected long enemyLevel;
    protected long enemyAtk;
    protected long enemyHp;
    protected string enemyName;
    public EnemyClass()
    {
        enemyLevel = 1;
        enemyAtk = 1;
        enemyHp = 1;
        enemyName = "empty";
    }
    public EnemyClass(long enemyLevel, long enemyAtk, long enemyHp, string enemyName)
    {
        this.enemyLevel = enemyLevel;
        this.enemyAtk = enemyAtk;
        this.enemyHp = enemyHp;
        this.enemyName = enemyName;
    }

    public long GetHp()
    {
        return enemyHp;
    }
    public long GetAtk()
    {
        return enemyAtk;
    }
    public long Getlevel()
    {
        return enemyLevel;
    }
    public string GetName()
    {
        return enemyName;
    }
}
