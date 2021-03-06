﻿using BLL;
using Entidades;
using ProyectoFinalWeb.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinalWeb.Registros
{
    public partial class rSuplidores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
              
            }

        }

        protected void NuevoBtton_Click(object sender, EventArgs e)
        {
            Clean();  
        }
        private void Clean()
        {
            SuplidorIdTextBox.Text = "0";
            NombreTextbox.Text = "";
            DireccionTextBox.Text = "";
            CedulaTextBox.Text = "";
            TelefonoTextBox.Text = "";
            CuentaTextbox.Text = "0";
            EmailTextBox.Text = "";
        }

        private Suplidores LlenaClase()
        {
            Suplidores suplidor = new Suplidores();

            suplidor.SuplidorId = Util.ToInt(SuplidorIdTextBox.Text);
            suplidor.Nombre = NombreTextbox.Text;
            DateTime date;
            bool resul = DateTime.TryParse(FechaTextBox.Text, out date);
            if (resul == true)
                suplidor.FechaIngreso = date;
            suplidor.Direccion = DireccionTextBox.Text;
            suplidor.Cedula = CedulaTextBox.Text;
            suplidor.Telefono = TelefonoTextBox.Text;
            suplidor.Email = EmailTextBox.Text;

            return suplidor;

        }
        private void LlenaCampos(Suplidores suplidor)
        {
            NombreTextbox.Text = suplidor.Nombre;
            DireccionTextBox.Text = suplidor.Direccion;
            CedulaTextBox.Text = suplidor.Cedula;
            TelefonoTextBox.Text = suplidor.Telefono;
            EmailTextBox.Text = suplidor.Email;
            CuentaTextbox.Text = suplidor.CuentasPorPagar.ToString();

        }
        protected bool Valida(Suplidores suplidor)
        {

            bool validar = false;
            Expression<Func<Suplidores, bool>> filtrar = m => true;
            RepositorioBase<Suplidores> repositorio = new RepositorioBase<Suplidores>();
            var Valicedula = repositorio.GetList(d => true);
            foreach (var item in Valicedula)
            {
                if (suplidor.Cedula == item.Cedula)
                {
                    Util.ShowToastr(this.Page, "Datos existente", "Error", "Error");
                    return validar = true;
                }
            }
            if(Util.ToInt(SuplidorIdTextBox.Text) > 0)
            {
                Util.ShowToastr(this.Page, "Debe estar en 0", "Error", "Error");
                return validar = true;
            }
            return validar;
        }
        protected void GuardarBtton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            Suplidores supli = new Suplidores();
            RepositorioBase<Suplidores> repo = new RepositorioBase<Suplidores>();

            if (IsValid == false)
            {
                Util.ShowToastr(this.Page, " Campos Vacios", "Error", "Error");
            }

            supli = LlenaClase();
            if (Valida(supli))
            {
                return;
            }
            else
            {
                if (Util.ToInt(SuplidorIdTextBox.Text) == 0)
                {
                    paso = repo.Guardar(supli);
                    Util.ShowToastr(this.Page, "Guardado con EXITO", "Guardado", "Success");
                    Clean();
                }
                else
                {
                    paso = repo.Modificar(supli);
                    Util.ShowToastr(this.Page, "Modificado con EXITO", "Guardado", "Success");
                    Clean();
                }

                if (paso)
                {
                    Clean();
                }
                else
                {
                    Util.ShowToastr(this.Page, "No se pudo Guardar", "Error", "Error");
                }
            }
        
        }
        

        protected void EliminarBtton_Click(object sender, EventArgs e)
        {
            int id = Util.ToInt(SuplidorIdTextBox.Text);
            RepositorioBase<Suplidores> repo = new RepositorioBase<Suplidores>();

            if (repo.Eliminar(id))
            {
                Util.ShowToastr(this.Page, " Eliminado con EXITO", "Eliminado", "Success");
                Clean();
            }
            else

                Util.ShowToastr(this.Page, " No se pudo eliminar", "Error", "Error");
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Suplidores> repo = new RepositorioBase<Suplidores>();
            Suplidores suplidor = new Suplidores();
            suplidor = repo.Buscar(Util.ToInt(SuplidorIdTextBox.Text));

            if (suplidor != null)
            {

                LlenaCampos(suplidor);

                Util.ShowToastr(this.Page, "Su busqueda fue exitosa", "EXITO", "Info");
            }
            else
            {
                Util.ShowToastr(this.Page, " No existe", "Error", "Error");
                Clean();
            }
        }
    }
}