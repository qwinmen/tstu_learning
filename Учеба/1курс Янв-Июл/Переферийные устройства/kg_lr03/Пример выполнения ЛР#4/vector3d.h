#ifndef __VECTOR3D__
#define __VECTOR3D__

#include "math.h"

class vector3d
{
public:
    float x,y,z;

    vector3d() { x = y = z = 0; };
    vector3d(float px, float py, float pz)
    {
        x = px;
        y = py;
        z = pz;
    }

    vector3d(const vector3d &v)
    {
        x = v.x;
        y = v.y;
        z = v.z;
    }

    vector3d &operator = (const vector3d &v)
    {
        x = v.x;
        y = v.y;
        z = v.z;
        return *this;
    }

    vector3d operator + () const
    {
        return *this;
    }

    vector3d operator - () const
    {
        return vector3d(-x,-y,-z);
    }

    vector3d& operator += (const vector3d& v)
    {
        x += v.x;
        y += v.y;
        z += v.z;
        return *this;
    }

    vector3d& operator -= (const vector3d& v)
    {
        x -= v.x;
        y -= v.y;
        z -= v.z;
        return *this;
    }

    vector3d& operator *= (const vector3d& v)
    {
        x *= v.x;
        y *= v.y;
        z *= v.z;
        return *this;
    }

    vector3d& operator *= (float f)
    {
        x *= f;
        y *= f;
        z *= f;
        return *this;
    }

    vector3d& operator /= (const vector3d& v)
    {
        x /= v.x;
        y /= v.y;
        z /= v.z;
        return *this;
    }

    vector3d& operator /= (float f)
    {
        x /= f;
        y /= f;
        z /= f;
        return *this;
    }

    float &operator [] (int index)
    {
        return *(index+&x);
    }

    int operator == (const vector3d &v) const
    {
        return (x==v.x) && (y==v.y) && (z==v.z);
    }

    int operator != (const vector3d &v) const
    {
        return (x!=v.x) || (y!=v.y) || (z!=v.z);
    }

    int operator < (const vector3d &v) const
    {
        return (x<v.x) || ((x==v.x) && (y<v.y));
    }

    int operator > (const vector3d &v) const
    {
        return (x>v.x) || ((x==v.x) && (y>v.y));
    }

    float length() const
    {
        return (float) sqrt(x*x+y*y+z*z);
    }

    friend vector3d operator + (const vector3d&, const vector3d&);
    friend vector3d operator - (const vector3d&, const vector3d&);
    friend vector3d operator * (const vector3d&, const vector3d&);
    friend vector3d operator * (float, const vector3d&);
    friend vector3d operator * (const vector3d&, float);
    friend vector3d operator / (const vector3d&, float);
    friend vector3d operator / (const vector3d&, const vector3d&);
    friend float    operator & (const vector3d&, const vector3d&);
    friend vector3d operator ^ (const vector3d&, const vector3d&);
};

inline vector3d operator + (const vector3d &u, const vector3d &v)
{
    return vector3d(u.x+v.x, u.y+v.y, u.z+v.z);
}

inline vector3d operator - (const vector3d &u, const vector3d &v)
{
    return vector3d(u.x-v.x, u.y-v.y, u.z-v.z);
}

inline vector3d operator * (const vector3d &u, const vector3d &v)
{
    return vector3d(u.x*v.x, u.y*v.y, u.z*v.z);
}

inline vector3d operator * (const vector3d &u, float a)
{
    return vector3d(u.x*a, u.y*a, u.z*a);
}

inline vector3d operator * (float a,const vector3d &u)
{
    return vector3d(u.x*a, u.y*a, u.z*a);
}

inline vector3d operator / (const vector3d &u, const vector3d &v)
{
    return vector3d(u.x/v.x, u.y/v.y, u.z/v.z);
}

inline vector3d operator / (const vector3d &u, float a)
{
    return vector3d(u.x/a, u.y/a, u.z/a);
}

inline float operator & (const vector3d &u, const vector3d &v)
{
    return (float)(u.x*v.x+u.y*v.y+u.z*v.z);
}

inline vector3d operator ^ (const vector3d &u, const vector3d &v)
{
    return vector3d(u.y*v.z-u.z*v.y,
                    u.z*v.x-u.x*v.z,
                    u.x*v.y-u.y*v.x);
}

#endif