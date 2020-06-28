using System;
using System.Collections.Generic;
using System.Text;

namespace Independency
{
    interface IIndependentManager
    {
        /// <summary>
        /// Load configuration to the system
        /// </summary>
        /// <param name="dependents"></param>
        public void LoadCOnfiguration(List<DependentItemConfig> dependents);

        /// <summary>
        /// Get list of One or more Independent items (has no parent)
        /// </summary>
        /// <returns></returns>
        public List<int> GetIndependenList();

        /// <summary>
        /// Set Success status for Item (should be Independent before)
        /// </summary>
        /// <param name="Id"></param>
        public void SetSuccess(int Id);

        /// <summary>
        ///  Set Fail status for Item (Should be Indepenedent before - child item will not be run)
        /// </summary>
        /// <param name="Id"></param>
        public void SetFail(int Id);



    }
}
