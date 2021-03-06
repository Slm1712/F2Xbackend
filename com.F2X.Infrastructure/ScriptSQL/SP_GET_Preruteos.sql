USE [TecnoCEDI_bd]
GO
/****** Object:  StoredProcedure [dbo].[SP_GET_Preruteos]    Script Date: 15/11/2019 11:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE  [dbo].[SP_GET_Preruteos]

AS
BEGIN
SET DATEFORMAT DMY
SELECT		
       [preRuteoId] 
	  ,CONVERT(VARCHAR(10),[preRuteoFecha], 103) AS [preRuteoFecha]
      ,[preRuteoUsuario]
      ,[preRuteoConsecutivo]
      ,[documentoId]
      ,[preRuteoPedidoEstado]

 FROM [dbo].[Preruteos] p


WHERE p.preRuteoPedidoEstado = 0
END
GO
