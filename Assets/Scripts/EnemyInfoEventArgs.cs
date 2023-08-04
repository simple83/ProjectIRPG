using System;

public class EnemyInfoEventArgs : EventArgs
{
    public EnemyStats enemyStats;

    public EnemyInfoEventArgs(EnemyStats enemyStats)
    {
        this.enemyStats = enemyStats;
    }
}
