<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Crud._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-12">

            <asp:Button runat="server" OnClick="Nuevo_Click" CssClass="btn btn-sm btn-success" Text="Nuevo" />
        </div>

    </div>

     <div class="row">
        <div class="col-12">

            <asp:GridView ID="GVEmpleado" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false">
                <columns>
                    <asp:BoundField DataField="Nombres" HeaderText="Nombres" />
                    <asp:BoundField DataField="Apellidos" HeaderText="Apellidos" />
                    <asp:BoundField DataField="Departamento.Nombre" HeaderText="Departamento" />
                    <asp:BoundField DataField="Sueldo" HeaderText="Sueldo" />
                    <asp:BoundField DataField="FechaContrato" HeaderText="Fecha de Contrato" />

                    <asp:TemplateField>
                       <ItemTemplate>
                           <asp:LinkButton runat="server" CommandArgument='<%# Eval("IdEmpleado")%>'
                               OnClick="Editar_Click" CssClass="btn btn-sm btn-primary"
                               >Editar</asp:LinkButton> 

                             <asp:LinkButton runat="server" CommandArgument='<%# Eval("IdEmpleado")%>'
                               OnClick="Eliminar_Click" CssClass="btn btn-sm btn-danger" OnClientClick="return confirm('Desea Eliminar?')"
                               >Eliminar</asp:LinkButton>

                       </ItemTemplate> 

                    </asp:TemplateField>

                </columns>
                               
                </asp:GridView>
            

        </div>

    </div>
</asp:Content>
