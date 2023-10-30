// components/BookViewer.js
"use client";
import { useEffect, useState } from 'react';

const HTMLViewer = (props) => {
  const [htmlContent, setHTMLContent] = useState('');
  
  console.log('inside reading state')
  console.log(props);

  useEffect(() => {
    // Fetch the HTML content for the selected book
    fetch(props.src)
      .then((response) => response.text())
      .then((data) => {
        setHTMLContent(data);
      })
      .catch((error) => {
        console.error('Error loading the book:', error);
      });
  }, [props]);

  return (
    <div
      style={{
        fontFamily: 'Georgia, serif',
        fontSize: '1.2rem',
        lineHeight: '1.5',
        letterSpacing: '0.01rem',
        textAlign: 'justify',
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
