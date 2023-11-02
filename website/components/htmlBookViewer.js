// components/BookViewer.js
"use client";
import { useEffect, useState } from 'react';
import { getFontSize, getFonts,  getLineHeight,  getLineSpacing,  getAlign,  getLayout,  } from  "../redux/readerSlice";
import{useSelector}from  "react-redux";

const HTMLViewer = (props) => {
  const [htmlContent, setHTMLContent] = useState('');
  const  fontSize = useSelector(getFontSize);
  const  fonts = useSelector(getFonts);
  const  lineHeight = useSelector(getLineHeight);
  const  lineSpacing = useSelector(getLineSpacing);
  const  alignment = useSelector(getAlign);
  const  layout = useSelector(getLayout);
  
  console.log('inside reading state')
  console.log(props);

  useEffect(() => {
    if (props.src === undefined) {
      return;
    }
    // Fetch the HTML content for the selected book
    fetch(props.src)
      .then((response) => response.text())
      .then((data) => {
        setHTMLContent(data);
      })
      .catch((error) => {
        console.error('Error loading the book:', error);
      });

  }, [props.src]);

  return (
    <div
      style={{
        fontFamily: fonts,
        fontSize: fontSize+'px',
        lineHeight: lineHeight+'px',
        letterSpacing: lineSpacing+'px',
        textAlign: alignment,
        backgroundColor: 'white',
        // margin: '4rem auto',
        marginLeft: '15%',
        marginRight: '10%',
      }}
      dangerouslySetInnerHTML={{ __html: htmlContent }}
    />
  );
};

export default HTMLViewer;
