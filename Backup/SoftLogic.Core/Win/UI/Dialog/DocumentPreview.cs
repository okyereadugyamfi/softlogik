namespace SoftLogik.Win.UI.Controls
{ 
public partial class Preview
{

}

public static class DefaultPreview
{
    private static Preview m_objPreview = new Preview();

    public static Preview Preview
    {
        get
        {
            return m_objPreview;
        }
    }
}

}
