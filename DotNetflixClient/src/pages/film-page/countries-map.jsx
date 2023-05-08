import { YMaps, Map, Placemark } from '@pbe/react-yandex-maps';
import { useState, useEffect } from "react";
import './countries-map.css'

export const CountriesMap = ({countries}) => {
    const { height, width } = useWindowDimensions();
    let params = getMapParams({width})
    const mapState = { center: [0, 12], zoom: params.zoom};

    return(
      <div>
        <div style={{position: "absolute", width: params.width, height: params.height, zIndex: 1}}></div>
        <YMaps>
          <Map width={params.width} height={params.height} state={mapState}>   
            {countries.map((c) => 
                <Placemark
                geometry={
                  [c.lat, c.lng]
                }
                properties={{
                  iconCaption: c.name,
                }}
                options={{
                  iconImageSize: [300, 420],
                  iconImageOffset: [-3, -42]
                }}
              />
            )}  
          </Map>
        </YMaps>        
    </div>)
};

function getMapParams({width})
{
  if(width >= 1500)
    return {
      zoom: 2,
      width: 1024,
      height: 700
    }
  if(width >= 990)
  return {
    zoom: 1,
    width: 512,
    height: 350
  }
  else
  return {
    zoom: -1,
    width: 256,
    height: 175
  }
}

function getWindowDimensions() {
    const { innerWidth: width, innerHeight: height } = window;
    return {
      width,
      height
    };
  }
export default function useWindowDimensions() {
    const [windowDimensions, setWindowDimensions] = useState(getWindowDimensions());
    useEffect(() => {
      function handleResize() {
        setWindowDimensions(getWindowDimensions());
      }
      window.addEventListener('resize', handleResize);
      return () => window.removeEventListener('resize', handleResize);
    }, []);
    return windowDimensions;
  }