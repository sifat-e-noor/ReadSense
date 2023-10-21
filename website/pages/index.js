import Head from 'next/head';
import Layout, { siteTitle } from '../components/layout';
import utilStyles from '../styles/utils.module.css';
import BasicTextFields from '../components/textfield';
import landing from '../styles/landing.module.css';
import Button from '@mui/material/Button';
import Image from 'next/image';
import styles from '../components/button.module.css';
import Link from 'next/link';

export default function Home() {
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
              <BasicTextFields/>    
              <Button variant="contained" sx= {{width: '238px'}} className={styles.buttonFilled}>Remember me</Button> 
          </div>
        </div>
      </div>
   </>
    // <Layout home>
      // {/* <Head> */}
        // {/* <title>{siteTitle}</title> */}
      // {/* </Head> */}
      // {/* <section className={utilStyles.headingMd}> */}
        // {/* <p>[Your Self Introduction]</p> */}
        // {/* <p> */}
          // {/* (This is a sample website - you’ll be building a site like this on{' '} */}
          // {/* <a href="https://nextjs.org/learn">our Next.js tutorial</a>.) */}
        // {/* </p> */}
      // {/* </section> */}
    // {/* </Layout> */}
  );
}