namespace ecs.Enum
{
    /// <summary>
    /// 目标选择类型
    /// </summary>
    public enum TargetType
    {
        Single, // 单体
        Rectangle, // 矩形区域
        AreaCircle, // 圆形区域
        FieldRectangle, // 战场重点为参考点的矩形区域
        FieldCircle, // 战场重点为参考点的圆形区域
        Random, // 随机
    }
}