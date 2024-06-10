namespace Logic.Enum
{
    /// <summary>
    /// 行为，修改属性、添加buff、触发特殊技能
    /// </summary>
    public enum ActionType
    {
        Property,
        Buff,
        RemoveBuff,
        AddBuff,
        CreateObject, // 创建物体，如子弹、陷阱等
    }
}