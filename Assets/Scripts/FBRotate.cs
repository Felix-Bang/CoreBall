//  Felix-Bang：FBRotate
//　　 へ　　　　　／|
//　　/＼7　　　 ∠＿/
//　 /　│　　 ／　／
//　│　Z ＿,＜　／　　 /`ヽ
//　│　　　　　ヽ　　 /　　〉
//　 Y　　　　　`　 /　　/
//　ｲ●　､　●　　⊂⊃〈　　/
//　()　 へ　　　　|　＼〈
//　　>ｰ ､_　 ィ　 │ ／／
//　 / へ　　 /　ﾉ＜| ＼＼
//　 ヽ_ﾉ　　(_／　 │／／
//　　7　　　　　　　|／
//　　＞―r￣￣`ｰ―＿
// Describe：自身旋转
// Createtime：2018/10/21

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Felix
{
	public class FBRotate : MonoBehaviour
	{
        #region 字段
        /// <summary> 旋转方向 </summary>
        public bool F_IsClockwise_Bool;
        /// <summary> 旋转速度 </summary>
        public float F_Speed_F;
        #endregion
        
        #region Unity回调
		void Update ()
		{
            if(F_IsClockwise_Bool)
                transform.Rotate(new Vector3(0, 0, -F_Speed_F * Time.deltaTime));
            else
                transform.Rotate(new Vector3(0, 0, F_Speed_F * Time.deltaTime));
        }
        #endregion

 
	}
}
