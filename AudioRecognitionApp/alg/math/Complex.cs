﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioRecognitionApp.alg.math
{
    public class Complex
    {
        public double re { get; set; } // the real part
        private double im { get; set; } // the imaginary part

        // create a new object with the given real and imaginary parts
        public Complex(double real, double imag)
        {
            re = real;
            im = imag;
        }

        // return a string representation of the invoking Complex object
        public String toString()
        {
            if (im == 0)
                return re + "";
            if (re == 0)
                return im + "i";
            if (im < 0)
                return re + " - " + (-im) + "i";
            return re + " + " + im + "i";
        }

        // return abs/modulus/magnitude and angle/phase/argument
        public double abs()
        {
            return Math.Sqrt(re * re + im * im);
        } // Math.sqrt(re*re + im*im)

        public double phase()
        {
            return Math.Atan2(im, re);
        } // between -pi and pi

        // return a new Complex object whose value is (this + b)
        public Complex plus(Complex b)
        {
            Complex a = this; // invoking object
            double real = a.re + b.re;
            double imag = a.im + b.im;
            return new Complex(real, imag);
        }

        // return a new Complex object whose value is (this - b)
        public Complex minus(Complex b)
        {
            Complex a = this;
            double real = a.re - b.re;
            double imag = a.im - b.im;
            return new Complex(real, imag);
        }

        // return a new Complex object whose value is (this * b)
        public Complex times(Complex b)
        {
            Complex a = this;
            double real = a.re * b.re - a.im * b.im;
            double imag = a.re * b.im + a.im * b.re;
            return new Complex(real, imag);
        }

        // scalar multiplication
        // return a new object whose value is (this * alpha)
        public Complex times(double alpha)
        {
            return new Complex(alpha * re, alpha * im);
        }

        // return a new Complex object whose value is the conjugate of this
        public Complex conjugate()
        {
            return new Complex(re, -im);
        }

        // return a new Complex object whose value is the reciprocal of this
        public Complex reciprocal()
        {
            double scale = re * re + im * im;
            return new Complex(re / scale, -im / scale);
        }

        // return the real or imaginary part


        // return a / b
        public Complex divides(Complex b)
        {
            Complex a = this;
            return a.times(b.reciprocal());
        }

        // return a new Complex object whose value is the complex exponential of
        // this
        public Complex exp()
        {
            return new Complex(Math.Exp(re) * Math.Cos(im), Math.Exp(re)
                    * Math.Sin(im));
        }

        // return a new Complex object whose value is the complex sine of this
        public Complex sin()
        {
            return new Complex(Math.Sin(re) * Math.Cosh(im), Math.Cos(re)
                    * Math.Sinh(im));
        }

        // return a new Complex object whose value is the complex cosine of this
        public Complex cos()
        {
            return new Complex(Math.Cos(re) * Math.Cosh(im), -Math.Sin(re)
                    * Math.Sinh(im));
        }

        // return a new Complex object whose value is the complex tangent of this
        public Complex tan()
        {
            return sin().divides(cos());
        }

        // a static version of plus
        public static Complex plus(Complex a, Complex b)
        {
            double real = a.re + b.re;
            double imag = a.im + b.im;
            Complex sum = new Complex(real, imag);
            return sum;
        }

        public static Complex Exp(Complex z)
        {
            double e = Math.Exp(z.re);
            double r = Math.Cos(z.im);
            double i = Math.Sin(z.im);

            return new Complex(e * r, e * i);
        }

        public Complex Add(Complex z)
        {
            return new Complex(re + z.re, im + z.im);
        }

        public Complex Sub(Complex z)
        {
            return new Complex(re - z.re, im - z.im);
        }

        public Complex Mul(Complex z)
        {
            double r = re * z.re - im * z.im;
            double i = re * z.im + im * z.re;

            return new Complex(r, i);
        }

    }
}
