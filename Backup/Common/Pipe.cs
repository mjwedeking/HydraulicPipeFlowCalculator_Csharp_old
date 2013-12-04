using System;

namespace HydraulicCalc.Common
{
	/// <summary>
	/// Pipe groups.
	/// </summary>
	public class Pipe
	{
		/// <summary>
		/// flow rate
		/// </summary>
		private double _flow;
		/// <summary>
		/// depth of flow
		/// </summary>
		private double _depth;
		private double _velocity;
		private double _diameter;
		private double _slope;
		private double _nvalue;
        private double depthitterations;

		public Pipe()
		{
			//
			// TODO: Add constructor logic here
			//
			_depth = 0;
			_flow = 0;
			_velocity = 0;
			_diameter = 0;
			_slope = 0;
			_nvalue = 0.013;
		}
		
		public double Flow
		{
			get {return _flow;}
			set {_flow = value;}
		}
		
		public double Depth 
		{
			get {return _depth;}
			set {_depth = value;}
		}

		public double Velocity 
		{
			get {return _velocity;}
			set {_velocity = value;}
		}

		public double Diameter 
		{
			get {return _diameter;}
			set {_diameter = value;}
		}

		public double Slope 
		{
			get {return _slope;}
			set {_slope = value;}
		}

		public double Nvalue 
		{
			get {return _nvalue;}
			set {_nvalue = value;}
		}

		/// <summary>
		/// Calculate the Flow and Velocity given the Depth
		/// </summary>
		/// <remarks>
		/// Calculates wetted perimiter dblWPerim
		/// calculates wetted area dblArea
		/// Uses V = 1.486/n * (A/P)^(2/3)* S^(1/2)
		/// and  Q = V * A
		/// </remarks>
		public bool QManning()
		{
			double dblTheta = 0;
			///<summary>
			///Wetted Perimiter
			///</summary>
			double dblWPerim = 0;
			///<summary>
			///Wetted Cross Sectional Area
			///</summary>
			double dblWArea = 0;
			///<summary>
			///Pipe Radius
			///</summary>
			double dblRadius = _diameter / 2;        //pipe radius

			_flow = 0;
			_velocity = 0;

			if (_depth == _diameter)
				dblTheta = 2 * Math.PI;   //full pipe theta is 2 pi
			else
				dblTheta = 2 * (Math.Acos((dblRadius - (_depth)) / dblRadius));
   
			dblWPerim = dblTheta * dblRadius;
			dblWArea = dblRadius *dblRadius * (dblTheta - Math.Sin(dblTheta)) / 2;
			_velocity = 1.486 / _nvalue * Math.Pow((dblWArea / dblWPerim),(2.0/3.0)) * Math.Pow(_slope,0.5);
			_flow = _velocity * dblWArea;

			return true;
		}

		/// <summary>
		/// Calculate the Flow given the Velocity and Depth
		/// </summary>
		/// <remarks>
		/// calculates wetted area dblArea
		/// Uses Q = V * A
		/// </remarks>
		public bool QVA()
		{
			double dblTheta = 0;
			double dblWArea = 0;                      //wetted cross sectional area
			double dblRadius = _diameter / 2;        //pipe radius

			_flow = 0;

			if (_depth == _diameter)
				dblTheta = 2 * Math.PI;   //full pipe theta is 2 pi
			else
				dblTheta = 2 * (Math.Acos((dblRadius - (_depth)) / dblRadius));
   
			dblWArea = dblRadius *dblRadius * (dblTheta - Math.Sin(dblTheta)) / 2;
			_flow = _velocity * dblWArea;

			return true;
		}
		/// <summary>
		/// Calculate the Velocity given the Flow and Depth
		/// </summary>
		/// <remarks>
		/// calculates wetted area dblArea
		/// Uses V = Q / A
		/// </remarks>
		public bool VQA()
		{
			double dblTheta = 0.0;
			double dblWArea = 0.0;                             //wetted cross sectional area
			double dblRadius = _diameter / 2.0;        //pipe radius

			_velocity = 0;

            if (_depth >= _diameter)
                dblWArea = Math.PI * Math.Pow(dblRadius, 2);   //full pipe theta is 2 pi
            else
            {
                dblTheta = 2 * (Math.Acos((dblRadius - (_depth)) / dblRadius));
                dblWArea = Math.Pow(dblRadius, 2) * (dblTheta - Math.Sin(dblTheta)) / 2.0;
            }
			_velocity = _flow / dblWArea;

			return true;
		}

		/// <summary>
		/// Calculate the Depth and Velocity given the Flow
		/// </summary>
		/// <remarks>
		/// Increments the depth by 0.0000001 ft until
		/// the given flow is calculated and retuns the
		/// resultant depth. Also calulates Velocity.
		/// </remarks>
		public bool DManning()
		{		
            double targetFlow = 0.0;

            targetFlow = _flow;
			_depth = 0.0;                              //depth of flow
			_velocity = 0.0;
			
			if (_slope <= 0)
			{
                _depth = double.NaN;
                _velocity = double.NaN;
			}
			else
            {
                _depth = 0.93818 * _diameter;
                QManning();
                if (targetFlow > _flow)
                {
                    _depth = double.NaN;
                    _velocity = double.NaN;
                }
                else
                {
                    DepthLoop(0, _depth, targetFlow);
                }
			}
			return true;
		}
        private bool DepthLoop(double lowDepth, double highDepth, double targetFlow)
        {
            double calculatedDepth;
            double range;

            range = 0.000001;
            depthitterations++;
            calculatedDepth = (highDepth + lowDepth) / 2;
            _depth = calculatedDepth;
            QManning();
            if(targetFlow < _flow * (1.0 - range))
                DepthLoop(lowDepth,calculatedDepth,targetFlow);
            if (targetFlow > _flow * (1.0 + range))
                DepthLoop(calculatedDepth, highDepth, targetFlow);

            return true;
        }
	}
}