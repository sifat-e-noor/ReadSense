
import * as React from 'react';
import Stack from '@mui/material/Stack';
import utilStyles from '../styles/utils.module.css';
import newusercontext from '../styles/newusercontext.module.css';
import Image from 'next/image';
import CustomRadioChip from '../components/CustomRadioChip';
import { useSession } from "next-auth/react";
import toast from "../components/Toast";
import { useRouter } from "next/router";
import { setEnvironmentId } from '../redux/readerSlice';
import { settoken } from '../redux/sessionSlice';
import { useDispatch } from 'react-redux';
import useAuth from '../components/useAuth';

export default function existingUserContext() {
  const [place, setPlace] = React.useState(undefined);
  const [location, setLocation] = React.useState(undefined);
  const [brightness, setBrightness] = React.useState(undefined);
  const router = useRouter();
  const { data: session } = useSession();
  const dispatch = useDispatch();
  const isAuthenticated = useAuth(true);

  React.useEffect(() => {
    if (session) {
      dispatch(settoken(session.token));
    }
  }, [session]);

  const notify = React.useCallback((type, message) => {
    toast({ type, message });
  }, []);

  const dismiss = React.useCallback(() => {
    toast.dismiss();
  }, []);

  //
  React.useEffect(() => {
    if (place && location && brightness) {
      console.log('place, location, brightness', place, location, brightness);
      handleAggreed({ placeState: place, location: location, brightnessLevel: brightness });
    }
  }, [place, location, brightness]);

  const handleAggreed = async ({ placeState, location, brightnessLevel }) => {
    notify("info", "We are saving your environment details.....");
    let res = undefined;
    try {
      res = await fetch(process.env.NEXT_PUBLIC_READSENSE_API_URL + '/api/environment', {
        body: JSON.stringify({
          placeState, location, brightnessLevel
        }),
        headers: {
          'Content-Type': 'application/json',
          'Authorization': 'Bearer ' + session.token,
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
      res.json().then((data) => {
        dispatch(setEnvironmentId(data.id));
        router.push('/existingUserPickStory');
      })
    } else if (res?.status === 401) {
      router.push('/login');
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
        notify("error", "Something went wrong. Please try again later.");
      });
    }
  }

  const placeRadioButtonFields = [
    { label: 'A quite place', value: 'Quiet' },
    { label: 'A chaotic place', value: 'Chaotic' },
  ];

  const youAreRadioButtonFields = [
    { label: 'At Home', value: 'Home' },
    { label: 'In Transportation', value: 'Transport' },
    { label: 'Outside', value: 'Outside' },
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
              <p>Hello Reader!<br />
                Good to see you again</p>
            </section>
            <section className={utilStyles.headingMd} style={{ marginLeft: '20px' }}>
              <p>Before we move on, tell us a bit about your current environment.
                As you know, It will help us to analyze more in detail.  </p>
            </section>
          </div>
          <div className={newusercontext.columnRightLower}>
            {/* <div className={newusercontext.columnRightLowerLeft}>
              <Stack  direction="column" className={utilStyles.headingMd}>
                <p>You are in ......</p>
                <p>You are...</p>
                <p>Environment light..</p>
              </Stack>
            </div> */}
            <div className={newusercontext.columnRightLowerRight}>
              <Stack spacing={3.5} direction="column" className={utilStyles.headingMd}>
                <Stack spacing={10} direction="row" className={utilStyles.headingMd}>
                  <p>You are in ......</p>
                  <Stack direction="column" spacing={1}>
                    <Stack spacing={2} direction="row" className={utilStyles.headingMd}>
                      <CustomRadioChip
                        handleClick={setPlace}
                        selected={place}
                        fields={placeRadioButtonFields}
                      />
                    </Stack>
                    <p style={{ color: 'gray', textAlign: 'start', fontStyle: 'italic', fontSize: '.8rem', margin: '0px' }}>Choose any</p>
                  </Stack>
                </Stack>
                <Stack spacing={17} direction="row" className={utilStyles.headingMd}>
                  <p>You are.......</p>
                  <Stack direction="column" spacing={1}>
                    <Stack spacing={2} direction="row" className={utilStyles.headingMd}>
                      <CustomRadioChip
                        handleClick={setLocation}
                        selected={location}
                        fields={youAreRadioButtonFields}
                      />
                    </Stack>
                    <p style={{ color: 'gray', textAlign: 'start', fontStyle: 'italic', fontSize: '.8rem', margin: '0px' }}>Choose any</p>
                  </Stack>
                </Stack>
                <Stack spacing={4} direction="row" className={utilStyles.headingMd}>
                  <p>Environment light...</p>
                  <Stack direction="column" spacing={1}>
                    <Stack spacing={2} direction="row" className={utilStyles.headingMd}>
                      <CustomRadioChip
                        handleClick={setBrightness}
                        selected={brightness}
                        fields={brightnessRadioButtonFields}
                      />
                    </Stack>
                    <p style={{ color: 'gray', textAlign: 'start', fontStyle: 'italic', fontSize: '.8rem', margin: '0px' }}>Choose any</p>
                  </Stack>
                </Stack>
                {/* <p style={{ color: 'gray', textAlign: 'start', fontStyle: 'italic', fontSize: '.8rem', margin: '0px' }}>Choose any</p> */}
                {/* <Stack spacing={2} direction="row" className={utilStyles.headingMd}>
                  <p>You are...</p>
                  <CustomRadioChip
                    handleClick={setLocation}
                    selected={location}
                    fields={youAreRadioButtonFields}
                  />
                </Stack> */}
                {/* <p style={{ color: 'gray', textAlign: 'start', fontStyle: 'italic', fontSize: '.8rem', margin: '0px' }}>Choose any</p> */}
                {/* <Stack spacing={2} direction="row" className={utilStyles.headingMd}>
                  <p>Environment light..</p>
                  <CustomRadioChip
                    handleClick={setBrightness}
                    selected={brightness}
                    fields={brightnessRadioButtonFields}
                  />
                </Stack> */}
                {/* <p style={{ color: 'gray', textAlign: 'start', fontStyle: 'italic', fontSize: '.8rem', margin: '0px' }}>Choose any</p> */}
              </Stack>
            </div>
          </div>
        </div>
      </div>
    </>
  );
}