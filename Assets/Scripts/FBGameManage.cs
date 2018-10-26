//  Felix-Bang：FBGameManage
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
// Describe：游戏核心
// Createtime：

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Felix
{
	public class FBGameManage : MonoBehaviour
	{
        #region 字段
        private Camera f_main_camera;
        private Transform f_start_trans;
        private Transform f_spawn_trans;

        [SerializeField]
        private Text f_score_text;
        [SerializeField]
        private GameObject f_prefab_obj;

        private FBPin f_current_pin;
        private int f_score_int = 0;
        private bool f_isgameover_bool;

        public float F_AniSpeed_F = 3;

        #endregion

        #region Unity回调
		void Start () 
		{
            f_main_camera = Camera.main;
            f_start_trans = GameObject.Find("StartPos").transform;
            f_spawn_trans = GameObject.Find("SpawnPos").transform;

            FBOnSpawnPin();
        }
	
		void Update ()
		{
            if (f_isgameover_bool) return;

            if (Input.GetMouseButtonDown(0))
            {
                f_score_int++;
                f_score_text.text = f_score_int.ToString();

                f_current_pin.FBOnStartFly();
                FBOnSpawnPin();
            }
		}
        #endregion


        #region 方法
        private void FBOnSpawnPin()
        {
            f_current_pin = GameObject.Instantiate(f_prefab_obj, f_spawn_trans).GetComponent<FBPin>();
        }

        public void FBOnGameOver()
        {
            if (f_isgameover_bool)
                return;

            GameObject.Find("Ball").GetComponent<FBRotate>().enabled = false;
            f_isgameover_bool = true;

            StartCoroutine(FBOnOverAnimation());
        }

        private IEnumerator FBOnOverAnimation()
        {
            while (true)
            {
                f_main_camera.backgroundColor = Color.Lerp(f_main_camera.backgroundColor,Color.red,Time.deltaTime*F_AniSpeed_F);
                f_main_camera.orthographicSize = Mathf.Lerp(f_main_camera.orthographicSize, 4f, Time.deltaTime * F_AniSpeed_F);

                if (Mathf.Abs(f_main_camera.orthographicSize - 4) < 0.01f)
                    break;

                yield return 0;
            }

            yield return new WaitForSeconds(1);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


        #endregion

    }
}
