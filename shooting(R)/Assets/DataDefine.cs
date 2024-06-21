using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataDefine
{
    public enum KeyAssign{
        UPPER = (int)KeyCode.W,
        LEFT = (int)KeyCode.A,
        LOWER = (int)KeyCode.S,
        RIGHT = (int)KeyCode.D,
        FLARE = (int)KeyCode.Q,
        TRIGGER = (int)KeyCode.Space,
    }
    public class PlayerClass
    {
        public enum PlayerState
        {
            ALIVE = 0,
            DEAD = 1,
            FLARE = 2,
            DAMAGING = 3,
        }
        private int life = 0;
        private int flareRemain = 0;
        private float moveSpeed = 1.0f;
        private float angleVelocity = 3.5f;

        public PlayerClass(int _life, int _flareRemain, float _moveSpeed, float _angleVelocity){
            life = _life;
            flareRemain = _flareRemain;
            moveSpeed = _moveSpeed;
            angleVelocity = _angleVelocity;
        }

        public int Damage(int damage)
        {
            life -= damage;
            if(life < 0)
            {
                life = -1;
            }
            return life;
        }

        public bool shotFlare(){
            if(flareRemain>=1)
            {
                flareRemain -= 1;
                return true;
            }else{
                return false;
            }
        }

        public int getLife(){return life;}
        public void setMoveSpeed(float speed){moveSpeed = speed;}
        public float getMoveSpeed(){return moveSpeed;}
        public float getAngleVelocity(){return angleVelocity;}
        public void setAngleVelocity(float _angleVelocity){angleVelocity = _angleVelocity;}
    }
}
