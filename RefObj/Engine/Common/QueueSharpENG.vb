Imports Engine.Common.ShopConnectDBENG
Imports System.Data.SqlClient

Namespace Common
    Public Class QueueSharpENG
        
        Public Shared Function MSTGetServicePriorityList()
            Dim dt As New DataTable
            Try
                Dim sql As String = " select rt.requisition_type_id, rt.requisition_type_name, rt.patent_type_id, rt.patent_type_name"
                sql += " from"
                sql += " 	(select rt.id requisition_type_id , rt.requisition_type_name, rt.order_seq, pt.id patent_type_id, pt.patent_type_name"
                sql += " 	from MS_REQUISITION_TYPE rt,MS_PATENT_TYPE pt) rt"
                sql += " left join MS_SERVICE_PRIORITY sp on rt.req_type_id=sp.ms_requisition_type_id and rt.patent_type_id=sp.ms_patent_type_id"
                sql += " left join MS_SERVICE s on s.id=sp.ms_service_id"
                sql += " order by rt.requisition_type_name, rt.order_seq,rt.patent_type_id"

                dt = FunctionEng.GetShopDataTable(sql)
            Catch ex As Exception
                dt = New DataTable
            End Try
            Return dt
        End Function
        
    End Class
End Namespace

