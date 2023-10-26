"use client";
import Head from 'next/head';
import Layout, { siteTitle } from '../components/layout';
import BasicTextFields from '../components/textfield';
import landing from '../styles/landing.module.css';
import Button from '@mui/material/Button';
import Image from 'next/image';
import styles from '../components/button.module.css';
import { signIn } from 'next-auth/react';
import * as React from 'react';
import FingerprintJS from '@fingerprintjs/fingerprintjs';
import { BrowserView, MobileView, isBrowser, isMobile, useDeviceData , useDeviceSelectors  } from 'react-device-detect';


export default function Home() {
  const [fpHash, setFpHash] = React.useState(undefined);
  const [components, setComponents] = React.useState({});
  const [deviceData, setDeviceData] = React.useState(undefined);

  React.useEffect(() => {
    const setBrowserInfo = async () => {
      const fp = await FingerprintJS.load();

      const { visitorId, components } = await fp.get();

      setFpHash(visitorId);
      setComponents(components);
    };

    const setDeviceInfo = async () => {
      const deviceData = useDeviceData()
      delete deviceData.UA;

      setDeviceData(deviceData)
    };
    setBrowserInfo().catch(console.error);
    setDeviceInfo().catch(console.error);
  }, []);

  const handleUsernameChange = (value) => {
    // Do nothing
  }

  const inputProps = {
    required: true,
    type: 'email',
    name: 'username',
  }

  const onSubmit = async (event) => {
    event.preventDefault()
    
    const doLogin = async () => {
      const formData = new FormData(event.currentTarget)
      const componentKeys = ["fonts", "languages", "colorDepth", "screenResolution", "timezone", "touchSupport"];
      const deviceInfo = { ...deviceData, fpHash, ...componentKeys.reduce((acc, key) => ({ ...acc, [key]: components[key] }), {})  };

      const result = await signIn('credentials', {
        redirect: true,
        username:formData.get('username'),
        password: '',
        deviceInfo: JSON.stringify(deviceInfo) ,
        callbackUrl: '/'
      })
    }

    if (fpHash === undefined || components === undefined || deviceData === undefined) {
      setTimeout(doLogin, 1000);
    } else {
      doLogin().catch(console.error);
    }
  }
  return (
    <>
      <Head><title>{siteTitle}</title></Head> 
      <div className={landing.container} >
        <div className={landing.columnLeft}>
          <div className={landing.columnLeftInner}>
          {/* <div style={{flex: 1, display: 'flex', flexDirection: 'row', backgroundColor: 'red', justifyContent: 'flex-end', alignItems: "center" }}> */}
            <Image
              src="/images/readers.jpg"
              width={0}
              height={0}
              sizes="100vw"
              style={{ width: 'auto', height: 'auto' }} // optional
            /> 
          </div>
        </div>
        <div className={landing.columnRight}>
          <div className={landing.columnRightUpper}>
            <Image
              src="/images/logo.jpg"
              width={0}
              height={0}
              sizes="100vw"
              style={{ width: 'auto', height: 'auto'}} // optional
              />
          </div>
          <div className={landing.columnRightLower}>
            <form onSubmit={onSubmit}>
              <BasicTextFields setCurrentValue = {handleUsernameChange} inputProps={inputProps} />    
              <Button type="submit"  variant="contained" sx= {{width: '238px'}} className={styles.buttonFilled}>Remember me</Button> 
            </form>
          </div>
          
        </div>
      </div>
   </>
  );
}