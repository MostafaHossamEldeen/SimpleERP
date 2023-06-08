<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PopUpCtl.ascx.cs" Inherits="VanSales.Controls.PopUpCtl" %>
  <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel"></h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
          <dx:ASPxGridView ID="grdviewdata" runat="server"></dx:ASPxGridView>
          <asp:HiddenField ID="fields" runat="server" ClientIDMode="Static" Value="<% DisplayFields %>" />
<input type="button" value="select" onclick="clickedf()" />
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
        <button type="button" class="btn btn-primary">Send message</button>
      </div>
    </div>
  </div>
</div>
<script>
    function clickedf() {
        debugger
        var ff = $('#fields').val();
        var f =ff.split(",")
        for (var i = 0; i < f.length; i++) {
          $('#' + f[i]).val('كنترول '+i)
        }
        $('#<%= ValueControle %>').val(1);
    }
</script>