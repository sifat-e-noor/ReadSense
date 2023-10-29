
import * as React from 'react';
import Stack from '@mui/material/Stack';
import utilStyles from '../styles/utils.module.css';
import newusercontext from '../styles/newusercontext.module.css';
import Image from 'next/image';
import Typography from '@mui/material/Typography';
import CustomRadioChip from '../components/CustomRadioChip';
import { useSession } from "next-auth/react";
import toast from "../components/Toast";
import { useRouter } from "next/router";

export default function newUserContext() {
  const [place, setPlace] = React.useState(undefined);
  const [time, setTime] = React.useState(undefined);
  const [brightness, setBrightness] = React.useState(undefined);
  const router = useRouter();
  const { data: session } = useSession();

  const notify = React.useCallback((type, message) => {
    toast({ type, message });
  }, []);

  const dismiss = React.useCallback(() => {
    toast.dismiss();
  }, []);

  React.useEffect(() => {
    if (place && time && brightness) {
      console.log('place, time, brightness', place, time, brightness);
      handleAggreed({placeState:place,timeOfDay:time,brightnessLevel:brightness});
    }
  }, [ place, time, brightness ]);

  const handleAggreed = async ({placeState,timeOfDay,brightnessLevel}) => {
    notify("info", "We are saving your environment details.....");
    let res = undefined;
    try {
      res = await fetch('http://localhost:5298/api/environment', {
        body: JSON.stringify({
          placeState,timeOfDay,brightnessLevel
        }),
        headers: {
          'Content-Type': 'application/json',
          'Authorization': 'Bearer ' + session.accessToken,
        },
        method: 'POST'
      });
    } catch (error) {
      dismiss();
      console.error('An unexpected error happened occurred:', error);
      notify("error", "Something went wrong. Please try again later.");
    }

    if (res?.status === 200) {
      dismiss();
      notify("success", "Environment details saved successfully.");
      router.push('/existingUserPickStory');
    } else {
      res?.json().then((data) => {
        dismiss();
        if (data.message) {
          notify("error", data.message);
        } else {
          notify("error", "Something went wrong. Please try again later.");
        }
        
      }).catch((err) => {
        console.log(err);
      });
    }
  }

  const placeRadioButtonFields = [
    { label: 'A quite place', value: 'Quiet' },
    { label: 'A chaotic place', value: 'Chaotic' },
  ];
  
  const timeRadioButtonFields = [
    { label: 'Morning', value: 'Morning' },
    { label: 'Day', value: 'Day' },
    { label: 'Evening', value: 'Evening' },
    { label: 'Night', value: 'Night' },
  ];

  const brightnessRadioButtonFields = [
    { label: 'Dark', value: 'Dark' },
    { label: 'Dim', value: 'Dim' },
    { label: 'Bright', value: 'Bright' },
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