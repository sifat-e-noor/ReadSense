import Head from 'next/head';
import Layout, { siteTitle } from '../components/layout';
import utilStyles from '../styles/utils.module.css';
import HTMLViewer from '../components/htmlBookViewer';
import { useRouter } from 'next/router';
import { getFontSize, getFonts, getLineHeight, getLineSpacing, getAlign, getLayout, getLastStableSettings, setLastStableSettings } from  "../redux/readerSlice";
import{useSelector, useDispatch}from  "react-redux";
import { useEffect, useState } from 'react';
import FeedBackModal from '../components/FeedBackModal';

export default function ReadingState(props) {
  const router = useRouter();
  const { bookContent } = router.query;
  const fontSize = useSelector(getFontSize);
  const fonts = useSelector(getFonts);
  const lineHeight = useSelector(getLineHeight);
  const lineSpacing = useSelector(getLineSpacing);
  const align = useSelector(getAlign);
  const layout = useSelector(getLayout);
  const lastStableSettings = useSelector(getLastStableSettings);
  const  dispatch = useDispatch();
  const [getFeedBack, setFeedBack] = useState(false);
  const [settingsDiff, setSettingsDiff] = useState({});
  const [settingsApplyTime, setSettingsApplyTime] = useState(new Date().toUTCString()); // time when settings were applied
  const [userInput, setUserInput] = useState({});

  // track changes in settings and show feedback modal
  useEffect(() => {
    if(lastStableSettings.fontSize != fontSize || lastStableSettings.fonts != fonts || lastStableSettings.lineHeight != lineHeight || lastStableSettings.lineSpacing != lineSpacing || lastStableSettings.align != align){
      const handler = setTimeout(() => {
        // find the settings that are different
        let diff = {};
        if(lastStableSettings.fontSize != fontSize){
          diff.fontSize = { old: lastStableSettings.fontSize, new: fontSize };
        }
        if(lastStableSettings.fonts != fonts){
          diff.fonts = { old: lastStableSettings.fonts, new: fonts };
        }
        if(lastStableSettings.lineHeight != lineHeight){
          diff.lineHeight = { old: lastStableSettings.lineHeight, new: lineHeight };
        }
        if(lastStableSettings.lineSpacing != lineSpacing){
          diff.lineSpacing = { old: lastStableSettings.lineSpacing, new: lineSpacing };
        }
        if(lastStableSettings.align != align){
          diff.align = { old: lastStableSettings.align, new: align };
        }
        if(lastStableSettings.layout != layout){
          diff.layout = { old: lastStableSettings.layout, new: layout };
        }

        setSettingsApplyTime(new Date().toUTCString());
        setSettingsDiff(diff);
        setFeedBack(true); // show the feedback modal
        dispatch(setLastStableSettings({...lastStableSettings, fontSize: fontSize, fonts: fonts, lineHeight: lineHeight, lineSpacing: lineSpacing, align: align}));
      }, 5000);
  
      return () => {
        console.log("clearing timeout");
        clearTimeout(handler);
      };
    }
  },[fontSize,fonts,lineHeight,lineSpacing,align,layout]);

  // on user input change, submit new userinput to backend
  useEffect(() => {
    
    if(Object.keys(userInput).length > 0){
      console.log("userInput: ", userInput);
      // submit user
      // fetch('/api/feedback', {
      //   method: 'POST',
      //   headers: {
      //     'Content-Type': 'application/json',
      //   },
      //   body: JSON.stringify( Object.keys(userInput).map(key => userInput[key]) ),
      // })
      // .then(response => response.json())
      console.log("submitted userInput: ", userInput);
      setUserInput({});
    }
  },[userInput]);

  const handleUserInput = (value) => {
    setUserInput({...userInput, ...value});
  }

  return (
    <Layout home>
      <Head>
        <title>{siteTitle}</title>
      </Head>
      <section className={utilStyles.bookText}>
        <div>
          <HTMLViewer src={bookContent} />
        </div>
      </section>
      <FeedBackModal isVisible={getFeedBack} handleClose={setFeedBack} settingsDiff={settingsDiff} settingsChangeTime={settingsApplyTime} handleSubmit={handleUserInput} />
    </Layout>
  );
}