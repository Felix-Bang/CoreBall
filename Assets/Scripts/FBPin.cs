//  Felix-Bang：FBPin
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
// Describe：
// Createtime：

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Felix
{
	public class FBPin : MonoBehaviour
	{
        #region 字段
        private Transform f_start_trans;
        private Transform f_ball_trans;
        private bool f_isfly_bool;
        private bool f_isreach_bool;
        public float F_Speed_F;
        private Vector3 f_end_vec;
        #endregion

        #region 属性
        #endregion

        #region Unity回调
        void Start()
        {
            f_start_trans = GameObject.Find("StartPos").transform;
            f_ball_trans = GameObject.Find("Ball").transform;
            f_end_vec = new Vector3(f_ball_trans.position.x, f_ball_trans.position.y - 1.25f, f_ball_trans.position.z);
        }
	
		void Update ()
		{
            if (f_isfly_bool)
            {
                transform.position = Vector3.MoveTowards(transform.position, f_end_vec, F_Speed_F * Time.deltaTime);
                if (Vector3.Distance(transform.position, f_end_vec) < 0.05f)
                {
                    transform.position = f_end_vec;
                    transform.parent = f_ball_trans;
                    f_isfly_bool = false;
                }
            }
            else
            {
                if (!f_isreach_bool)
                {
                    transform.position = Vector3.MoveTowards(transform.position, f_start_trans.position, F_Speed_F * Time.deltaTime);
                    if (Vector3.Distance(transform.position, f_start_trans.position) < 0.05f)
                        f_isreach_bool = true;
                }
            }
		}
        #endregion

        #region 方法
        public void FBOnStartFly()
        {
            f_isfly_bool = true;
            f_isreach_bool = true;
        }

      
        #endregion
	}
}
