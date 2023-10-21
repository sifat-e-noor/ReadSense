import Head from 'next/head';
import * as React from 'react';
import Stack from '@mui/material/Stack';
import Layout, { siteTitle } from '../components/layout';
import utilStyles from '../styles/utils.module.css';
import newusercontext from '../styles/newusercontext.module.css';
import Image from 'next/image';
import Typography from '@mui/material/Typography';
import DoneIcon from '@mui/icons-material/Done';
import DeleteIcon from '@mui/icons-material/Delete';
import Chip from '@mui/material/Chip';
import Link from 'next/link';
import { CheckCircle, CheckCircleOutlineRounded, Done, DoneAllOutlined, DoneOutlineRounded, TaskAlt } from '@mui/icons-material';
import { useState } from 'react';
import CustomRadioChip from '../components/CustomRadioChip';

export default function newUserContext() {
  const [place, setPlace] = React.useState(undefined);
  const [time, setTime] = React.useState(undefined);
  const [brightness, setBrightness] = React.useState(undefined);

  const placeRadioButtonFields = [
    { label: 'A quite place', value: 'quite' },
    { label: 'A chaotic place', value: 'chaotic' },
  ];
  
  const timeRadioButtonFields = [
    { label: 'Morning', value: 'morning' },
    { label: 'Day', value: 'day' },
    { label: 'Evening', value: 'evening' },
    { label: 'Night', value: 'night' },
  ];

  const brightnessRadioButtonFields = [
    { label: 'Low', value: 'low' },
    { label: 'Bright', value: 'bright' },
  ]
  
  const handleClick = () => {
    console.info('You clicked the Chip.');
  };
  
  return (
    <>
      <div className={newusercontext.container}>
        <div className={newusercontext.columnLeft}>
          <div className={newusercontext.columnLeftInner}>
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
        <div className={newusercontext.columnRight}>
          <div className={newusercontext.columnRightUpper}>
            <section className={utilStyles.headingXl}> 
              <p>Thanks,<br/>
              Much Appreciated!</p>
            </section> 
            <section className={utilStyles.headingMd} style={{ marginLeft: '20px' }}> 
              <p>Before we move on, tell us a bit about your current environment. 
              It will help us to analyze more in detail. </p>
            </section> 
          </div>
          <div className={newusercontext.columnRightLower}>
            <div className={newusercontext.columnRightLowerLeft}>
              <Stack spacing={6.2} direction="column" className={utilStyles.headingMd}>
                <Typography>You are in ......</Typography>
                <p>It’s a time of..</p>
                <p>Environment light..</p>
              </Stack>
            </div>
            <div className={newusercontext.columnRightLowerRight}>
              <Stack spacing={3.5} direction="column" className={utilStyles.headingMd}>
                <Stack spacing={2} direction="row" className={utilStyles.headingMd}> 
                  <CustomRadioChip
                    handleClick = {setPlace}
                    selected = {place}
                    fields = {placeRadioButtonFields}
                  />
                </Stack>
                <p style={{color:'gray', textAlign:'start', fontStyle: 'italic', fontSize:'.8rem', margin: '0px'}}>choose any</p>
                <Stack spacing={2} direction="row" className={utilStyles.headingMd}> 
                  <CustomRadioChip
                    handleClick = {setTime}
                    selected = {time}
                    fields = {timeRadioButtonFields}
                  />
                </Stack>
                <p style={{color:'gray', textAlign:'start', fontStyle: 'italic', fontSize:'.8rem', margin: '0px'}}>choose any</p>
                <Stack spacing={2} direction="row" className={utilStyles.headingMd}> 
                  <CustomRadioChip
                    handleClick = {setBrightness}
                    selected = {brightness}
                    fields = {brightnessRadioButtonFields}
                  />
                </Stack>
                <p style={{color:'gray', textAlign:'start', fontStyle: 'italic', fontSize:'.8rem', margin: '0px'}}>choose any</p>
              </Stack>
            </div> 
          </div> 
        </div>
      </div>
    </>
  );
}