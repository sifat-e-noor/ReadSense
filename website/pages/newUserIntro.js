import Head from 'next/head';
import * as React from 'react';
import Stack from '@mui/material/Stack';
import Layout, { siteTitle } from '../components/layout';
import utilStyles from '../styles/utils.module.css';
import BasicButtons from '../components/button';
import newuserintro from '../styles/newuserintro.module.css';
import styles from '../components/button.module.css';
import Button from '@mui/material/Button';
import Image from 'next/image';
import Link from 'next/link';

export default function Introduction() {
    return (
      <>
        <div className={newuserintro.container} >
          <div className={newuserintro.columnLeft}>
            <div className={newuserintro.columnLeftInner}>
            {/* <div style={{flex: 1, display: 'flex', flexDirection: 'row', backgroundColor: 'red', justifyContent: 'flex-end', alignItems: "center" }}> */}
            <Image
              src="/images/reader_image.jpg"
              width={0}
              height={0}
              sizes="100vw"
              style={{ width: 'auto', height: 'auto' }} // optional
            /> 
            </div>
          </div>
          <div className={newuserintro.columnRight}>
            <div className={newuserintro.columnRightUpper}>
            <section className={utilStyles.headingXl}> 
            <p>Hello Reader,<br/>
            Welcome to ReadSense!</p>
            </section> 
            <section className={utilStyles.headingMd} style={{ marginLeft: '20px' }}> 
                <p>ReadSense is data collection and users’ insight generating tool. 
                It is specifically designed to help researchers to collect data and find patterns 
                about users’ reading challenges and preferences 
                from user’s interactions with reading materials.</p>
                <p>And by using our app for a while to readout some of our
                reading materials, you will
                be a part of our research contributor community!!</p>
                <p>So do you agree to be a proud contributor in our research?</p>
            </section> 
            </div>
            <div className={newuserintro.columnRightLower}>   
            <Stack spacing={2} direction="row">
                {/* <Button variant="text">Text</Button> */}
                <Button variant="outlined" className={styles.buttonOutline}>No, I don't</Button>
                <Button variant="contained" className={styles.buttonFilled}>Yes, I agree</Button>
            </Stack>
            </div>
          </div>
        </div>
     </>
    );
  }