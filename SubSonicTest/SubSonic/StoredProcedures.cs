﻿


  
using System;
using System.Data;
using SubSonic.Schema;
using SubSonic.DataProviders;

namespace Solution.DataAccess.DataModel{
	public partial class SPs{

        public static StoredProcedure P_Branch_GetMaxBranchDeptCode(int Depth,int ParentID){
            StoredProcedure sp=new StoredProcedure("P_Branch_GetMaxBranchDeptCode");
			

            sp.Command.AddParameter("Depth",Depth,DbType.Int32);
            sp.Command.AddParameter("ParentID",ParentID,DbType.Int32);
            return sp;
        }
	
	}
	
}
 