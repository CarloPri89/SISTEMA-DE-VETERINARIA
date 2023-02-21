<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cliente
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cliente))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.a = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.sexo = New System.Windows.Forms.ComboBox()
        Me.id = New System.Windows.Forms.TextBox()
        Me.apellido = New System.Windows.Forms.TextBox()
        Me.telefono = New System.Windows.Forms.TextBox()
        Me.direccion = New System.Windows.Forms.TextBox()
        Me.nombre = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dni = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Geometr415 Blk BT", 11.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(91, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Registrar Cliente"
        '
        'a
        '
        Me.a.AutoSize = True
        Me.a.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.a.Location = New System.Drawing.Point(24, 42)
        Me.a.Name = "a"
        Me.a.Size = New System.Drawing.Size(64, 13)
        Me.a.TabIndex = 1
        Me.a.Text = "Registro Nª:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(41, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Nombre:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(41, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Apellido:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(54, 156)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Sexo:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(33, 181)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Dirección:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(36, 208)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 13)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Telefono:"
        '
        'sexo
        '
        Me.sexo.FormattingEnabled = True
        Me.sexo.Items.AddRange(New Object() {"M", "F", "Otros"})
        Me.sexo.Location = New System.Drawing.Point(94, 148)
        Me.sexo.Name = "sexo"
        Me.sexo.Size = New System.Drawing.Size(47, 21)
        Me.sexo.TabIndex = 8
        '
        'id
        '
        Me.id.Enabled = False
        Me.id.Location = New System.Drawing.Point(94, 39)
        Me.id.Name = "id"
        Me.id.Size = New System.Drawing.Size(168, 20)
        Me.id.TabIndex = 10
        '
        'apellido
        '
        Me.apellido.Location = New System.Drawing.Point(94, 91)
        Me.apellido.Name = "apellido"
        Me.apellido.Size = New System.Drawing.Size(168, 20)
        Me.apellido.TabIndex = 11
        '
        'telefono
        '
        Me.telefono.Location = New System.Drawing.Point(94, 205)
        Me.telefono.Name = "telefono"
        Me.telefono.Size = New System.Drawing.Size(98, 20)
        Me.telefono.TabIndex = 12
        '
        'direccion
        '
        Me.direccion.Location = New System.Drawing.Point(94, 178)
        Me.direccion.Name = "direccion"
        Me.direccion.Size = New System.Drawing.Size(168, 20)
        Me.direccion.TabIndex = 13
        '
        'nombre
        '
        Me.nombre.Location = New System.Drawing.Point(94, 65)
        Me.nombre.Name = "nombre"
        Me.nombre.Size = New System.Drawing.Size(168, 20)
        Me.nombre.TabIndex = 15
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(158, 242)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 51)
        Me.Button1.TabIndex = 20
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Black
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(66, 242)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 51)
        Me.Button2.TabIndex = 21
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(59, 124)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 13)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "DNI:"
        '
        'dni
        '
        Me.dni.Location = New System.Drawing.Point(94, 121)
        Me.dni.Name = "dni"
        Me.dni.Size = New System.Drawing.Size(168, 20)
        Me.dni.TabIndex = 24
        '
        'Cliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(316, 308)
        Me.Controls.Add(Me.dni)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.nombre)
        Me.Controls.Add(Me.direccion)
        Me.Controls.Add(Me.telefono)
        Me.Controls.Add(Me.apellido)
        Me.Controls.Add(Me.id)
        Me.Controls.Add(Me.sexo)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.a)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Cliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cliente"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents a As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents sexo As ComboBox
    Friend WithEvents id As TextBox
    Friend WithEvents apellido As TextBox
    Friend WithEvents telefono As TextBox
    Friend WithEvents direccion As TextBox
    Friend WithEvents nombre As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents dni As TextBox
End Class
