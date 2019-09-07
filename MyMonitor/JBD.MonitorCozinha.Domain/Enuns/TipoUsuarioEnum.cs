using System.ComponentModel;

namespace JBD.MonitorCozinha.Domain.Enuns
{
    public enum TipoUsuarioEnum
    {
        [Description("ADMINISTRADOR")]
        Admin = 1,  //Usuário administrador
        [Description("USUÁRIO")]
        User = 2,   //Usuário que tem acesso aos Monitores
        [Description("CONVIDADE")]
        Guest = 3,  //Usuário com acesso de demostração
        [Description("TESTE")]
        Test = 4,    //Usuário com acesso para testes
        [Description("OPERACIONAL")]
        Operacional = 5,    //Usuário com acesso para testes
        [Description("COZINHA")]
        Cozinha = 6,    //Usuário com acesso para testes
        [Description("MONITOR TV")]
        MonitorTV = 7    //Usuário com acesso para testes
    }
}
