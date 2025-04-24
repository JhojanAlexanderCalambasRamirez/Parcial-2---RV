using System;

[Serializable]
public class Usuario
{
    public string nombreUsuario;
    public int puntaje;

    public Usuario(string nombre, int puntaje)
    {
        this.nombreUsuario = nombre;
        this.puntaje = puntaje;
    }
}
