import Head from 'next/head';
import Layout, { siteTitle } from '../components/layout';
import utilStyles from '../styles/utils.module.css';
import BasicTextFields from '../components/textfield';
import landing from '../styles/landing.module.css';
import Button from '@mui/material/Button';
import Image from 'next/image';
import styles from '../components/button.module.css';
import Link from 'next/link';
import HTMLViewer from '../components/htmlBookViewer';

export default function Home() {
  return (
    <Layout home>
      <Head>
        <title>{siteTitle}</title>
      </Head>
      <section className={utilStyles.bookText}>
        <div>
          <HTMLViewer />
        </div>
      </section>
    </Layout>
  );
}