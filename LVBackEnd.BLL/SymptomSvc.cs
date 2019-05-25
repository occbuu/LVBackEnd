using Newtonsoft.Json;
using SKG.BLL;
using SKG.Ext;
using SKG.Req;
using SKG.Rsp;
using System;
using System.Linq;

namespace LVBackEnd.BLL
{
    using DAL;
    using DAL.Models;
    using Filter;
    using Microsoft.EntityFrameworkCore.Internal;
    using System.Collections.Generic;

    public class SymptomSvc : GenericSvc<SymptomRep, Symptom>
    {
        #region -- Overrides --

        public override SearchRsp Read(PagingReq req)
        {
            var res = new SearchRsp(req);
            try
            {
                // Get data
                var filter = new SymptomFilter();
                if (req.Filter != null)
                {
                    filter = JsonConvert.DeserializeObject<SymptomFilter>(req.Filter.ToString());
                }

                var page = req.Page;
                var size = req.Size;
                var offset = (page - 1) * size;
                var query = All;

                #region -- Filter --

                if (filter.Type != null)
                {
                    query = query.Where(p => p.Group == filter.Type);
                }

                #endregion

                res.TotalRecords = query.Count();

                if (req.Paging)
                {
                    query = query.OrderByDescending(p => p.Id)
                        .Sort(req.Sort)
                        .Skip(offset)
                        .Take(size);
                }

                var t = query.ToList();

                res.Data = t;
            }
            catch (Exception ex)
            {
                res.SetError(ex.StackTrace);
            }

            return res;
        }

        #endregion

        #region -- Methods --

        /// <summary>
        /// Initialize
        /// </summary>
        public SymptomSvc() { }

        /// <summary>
        /// Read symptom type 
        /// </summary>
        /// <returns>Return the result</returns>
        public SingleRsp ReadSymptomType()
        {
            var res = new SingleRsp
            {
                Data = _rep.Context.Symptom.Select(x => x.Group).ToList().Distinct()
            };

            return res;
        }

        class ProductComparer : IEqualityComparer<string>
        {
            // Products are equal if their names and product numbers are equal.
            public bool Equals(string x, string y)
            {
                if (x != y) return false;

                //Check whether any of the compared objects is null.
                if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                    return false;

                //Check whether the compared objects reference the same data.
                if (Object.ReferenceEquals(x, y)) return true;

                //Check whether the products' properties are equal.
                return x == y;
            }
            public int GetHashCode(string product)
            {
                if (product == "") return 0;

                //Check whether the object is null
                if (Object.ReferenceEquals(product, null)) return 0;

                //Get hash code for the Name field if it is not null.
                int hashProductName = product == null ? 0 : product.GetHashCode();

                //Get hash code for the Code field.
                int hashProductCode = product.GetHashCode();

                //Calculate the hash code for the product.
                return hashProductName ^ hashProductCode;
            }

        }

        public bool Check(string[] array, string[] array2)
        {
            foreach (var i in array)
            {
                if (array2.IndexOf(i) == -1) return false;
            }
            return true;
        }

        public SingleRsp Test()
        {
            List<string> lsOk = new List<string>();

            string[] sam = { "{118}", "{119}", "{120}" };

            var ls = _rep.Context.Rule.Select(x => x.Vt).ToList();

            foreach (var vt in ls)
            {
                var sam2 = vt.Split(',');
                var check = Check(sam, sam2);
                if (check) lsOk.Add(vt);
            }

            var query = (from a in _rep.Context.Rule
                         join b in _rep.Context.Disease on a.Vp equals b.Code
                         select new
                         {
                             a.Id,
                             a.Vt,
                             a.Vp,
                             a.RuleType,
                             b.Name
                         });

            var res = new SingleRsp
            {
                Data = _rep.Context.Symptom.Select(x => x.Group).ToList().Distinct()
            };

            return res;
        }

        #endregion

        #region -- Fields --

        #endregion
    }
}
