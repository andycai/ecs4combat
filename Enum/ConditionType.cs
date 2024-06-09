namespace ecs.Enum
{
    public enum ConditionType
    {
        // 主动技能触发条件
        ActiveDead = 0,
        
        // 被动技能触发条件
        PassiveDead = 100,
        PassiveAlive,
        PassiveRaceCount,
    }
}