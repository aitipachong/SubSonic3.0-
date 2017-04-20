 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using SubSonic.DataProviders;
using SubSonic.Extensions;
using System.Linq.Expressions;
using SubSonic.Schema;
using SubSonic.Repository;
using System.Data.Common;

namespace Solution.DataAccess.DataModel
{    
    /// <summary>
    /// A class which represents the Position table in the SubSonicTest Database.
    /// </summary>
    public partial class Position: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<Position> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<Position>(new Solution.DataAccess.DataModel.SubSonicTestDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<Position> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(Position item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                Position item=new Position();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<Position> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        Solution.DataAccess.DataModel.SubSonicTestDB _db;
        public Position(string connectionString, string providerName) {

            _db=new Solution.DataAccess.DataModel.SubSonicTestDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                Position.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Position>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public Position(){
			_db=new Solution.DataAccess.DataModel.SubSonicTestDB();
            Init();            
        }

		public void ORMapping(IDataRecord dataRecord)
        {
            IReadRecord readRecord = SqlReadRecord.GetIReadRecord();
            readRecord.DataRecord = dataRecord;   
               
            Id = readRecord.get_int("Id",null);
               
            Name = readRecord.get_string("Name",null);
               
            Branch_Id = readRecord.get_int("Branch_Id",null);
               
            Branch_DeptCode = readRecord.get_string("Branch_DeptCode",null);
               
            Branch_Name = readRecord.get_string("Branch_Name",null);
               
            PagePower = readRecord.get_string("PagePower",null);
               
            ControlPower = readRecord.get_string("ControlPower",null);
               
            IsFinance = readRecord.get_byte("IsFinance",null);
               
            IsSetBranchPower = readRecord.get_byte("IsSetBranchPower",null);
               
            SetDeptCode = readRecord.get_string("SetDeptCode",null);
               
            AddDate = readRecord.get_datetime("AddDate",null);
                }   

        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public Position(Expression<Func<Position, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<Position> GetRepo(string connectionString, string providerName){
            Solution.DataAccess.DataModel.SubSonicTestDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Solution.DataAccess.DataModel.SubSonicTestDB();
            }else{
                db=new Solution.DataAccess.DataModel.SubSonicTestDB(connectionString, providerName);
            }
            IRepository<Position> _repo;
            
            if(db.TestMode){
                Position.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Position>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<Position> GetRepo(){
            return GetRepo("","");
        }
        
        public static Position SingleOrDefault(Expression<Func<Position, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            Position single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static Position SingleOrDefault(Expression<Func<Position, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            Position single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<Position, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<Position, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<Position> Find(Expression<Func<Position, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<Position> Find(Expression<Func<Position, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<Position> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<Position> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<Position> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<Position> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<Position> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<Position> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "Id";
        }

        public object KeyValue()
        {
            return this.Id;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
			StringBuilder sb = new StringBuilder();
            			sb.Append("Id = " + Id + "\r\n");
            			sb.Append("Name = " + Name + "\r\n");
            			sb.Append("Branch_Id = " + Branch_Id + "\r\n");
            			sb.Append("Branch_DeptCode = " + Branch_DeptCode + "\r\n");
            			sb.Append("Branch_Name = " + Branch_Name + "\r\n");
            			sb.Append("PagePower = " + PagePower + "\r\n");
            			sb.Append("ControlPower = " + ControlPower + "\r\n");
            			sb.Append("IsFinance = " + IsFinance + "\r\n");
            			sb.Append("IsSetBranchPower = " + IsSetBranchPower + "\r\n");
            			sb.Append("SetDeptCode = " + SetDeptCode + "\r\n");
            			sb.Append("AddDate = " + AddDate + "\r\n");
            
			return sb.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(Position)){
                Position compare=(Position)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.Id;
        }
        
        public string DescriptorValue()
        {
                            return this.Name.ToString();
                    }

        public string DescriptorColumn() {
            return "Name";
        }
        public static string GetKeyColumn()
        {
            return "Id";
        }        
        public static string GetDescriptorColumn()
        {
            return "Name";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _Id;
		/// <summary>
		/// 主键Id
		/// </summary>
        public int Id
        {
            get { return _Id; }
            set
            {
                if(_Id!=value || _isLoaded){
                    _Id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Name;
		/// <summary>
		/// 职位名称
		/// </summary>
        public string Name
        {
            get { return _Name; }
            set
            {
                if(_Name!=value || _isLoaded){
                    _Name=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Name");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _Branch_Id;
		/// <summary>
		/// 部门自编号ID
		/// </summary>
        public int Branch_Id
        {
            get { return _Branch_Id; }
            set
            {
                if(_Branch_Id!=value || _isLoaded){
                    _Branch_Id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Branch_Id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Branch_DeptCode;
		/// <summary>
		/// 部门编号
		/// </summary>
        public string Branch_DeptCode
        {
            get { return _Branch_DeptCode; }
            set
            {
                if(_Branch_DeptCode!=value || _isLoaded){
                    _Branch_DeptCode=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Branch_DeptCode");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Branch_Name;
		/// <summary>
		/// 部门名称
		/// </summary>
        public string Branch_Name
        {
            get { return _Branch_Name; }
            set
            {
                if(_Branch_Name!=value || _isLoaded){
                    _Branch_Name=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Branch_Name");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _PagePower;
		/// <summary>
		/// 菜单操作权限，有操作权限的菜单ID列表：|1|2|3|4|5|
		/// </summary>
        public string PagePower
        {
            get { return _PagePower; }
            set
            {
                if(_PagePower!=value || _isLoaded){
                    _PagePower=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PagePower");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _ControlPower;
		/// <summary>
		/// 页面功能操作权限，各个页面有操作权限的菜单ID和页面权限标志ID列表：|1,1|2,1|2,2|2,4|
		/// </summary>
        public string ControlPower
        {
            get { return _ControlPower; }
            set
            {
                if(_ControlPower!=value || _isLoaded){
                    _ControlPower=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ControlPower");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        byte _IsFinance;
		/// <summary>
		/// 是否财务人员，0=否，1=是
		/// </summary>
        public byte IsFinance
        {
            get { return _IsFinance; }
            set
            {
                if(_IsFinance!=value || _isLoaded){
                    _IsFinance=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="IsFinance");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        byte _IsSetBranchPower;
		/// <summary>
		/// 是否有绑定指定部门操作权限，0=无，1=有 （对SetDeptCode操作限制，一般对于小型公司没有作用，对于全国性有多分公司企业，且各企业的人事或财务是各自独立的才有大作用）
		/// </summary>
        public byte IsSetBranchPower
        {
            get { return _IsSetBranchPower; }
            set
            {
                if(_IsSetBranchPower!=value || _isLoaded){
                    _IsSetBranchPower=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="IsSetBranchPower");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _SetDeptCode;
		/// <summary>
		/// 绑定有权限操作的部门，绑定后该职位进入部门或职位编辑时，只能编辑该部门里的相关信息
		/// </summary>
        public string SetDeptCode
        {
            get { return _SetDeptCode; }
            set
            {
                if(_SetDeptCode!=value || _isLoaded){
                    _SetDeptCode=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SetDeptCode");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime _AddDate;
		/// <summary>
		/// 创建时间
		/// </summary>
        public DateTime AddDate
        {
            get { return _AddDate; }
            set
            {
                if(_AddDate!=value || _isLoaded){
                    _AddDate=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="AddDate");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
				_repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }

        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<Position, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
}

